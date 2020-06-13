using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EveMinerHelperUI
{
    /// <summary>
    /// ModuleEditorWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class TargetEditorWindow : Window
    {
        public MainWindow Parent;
        public TargetEditorWindowData UIData = new TargetEditorWindowData();

        public TargetAsteroidData OldAsteroidData;

        public TargetEditorWindow(MainWindow window, TargetAsteroidData dataToEdit = null)
        {
            Parent = window;
            DataContext = UIData;
            OldAsteroidData = dataToEdit;

            InitializeComponent();

            if (OldAsteroidData != null)
            {
                UIData.OreAmount = OldAsteroidData.OreAmount;
                UIData.OreType = OldAsteroidData.OreType;
            }
        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            var response = MessageBox.Show("Are you sure you want to cancel?", "Confirmation",
                MessageBoxButton.OKCancel, MessageBoxImage.Warning);

            if (response != MessageBoxResult.OK)
            {
                return;
            }

            Parent.Focus();
            Close();
        }

        private void ConfirmButton_OnClick(object sender, RoutedEventArgs e)
        {
            var oreAmount = UIData.OreAmount;
            var oreType = UIData.OreType;
            var newAsteroidData = new TargetAsteroidData(oreAmount, oreType);

            if (OldAsteroidData != null)
            {
                // idk if this is the best way to go
                var find = Parent.UIData.Targets.IndexOf(OldAsteroidData);
                Parent.UIData.Targets[find] = newAsteroidData;
            }
            else
            {
                Parent.UIData.Targets.Add(newAsteroidData);
            }

            Parent.Focus();
            Close();
        }

        public class TargetEditorWindowData : INotifyPropertyChanged
        {
            private int _oreAmount;
            private string _oreType;

            public int OreAmount
            {
                get => _oreAmount;
                set
                {
                    _oreAmount = value;
                    Notify("OreAmount");
                }
            }

            public string OreType
            {
                get => _oreType;
                set
                {
                    _oreType = value;
                    Notify("OreType");
                }
            }

            public void Notify(string name)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }

            public event PropertyChangedEventHandler PropertyChanged;
        }
    }
}
