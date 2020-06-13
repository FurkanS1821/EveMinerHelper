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
    public partial class ModuleEditorWindow : Window
    {
        public MainWindow Parent;
        public ModuleEditorWindowData UIData = new ModuleEditorWindowData();

        public ModuleEditorWindow(MainWindow window, int index)
        {
            Parent = window;
            DataContext = UIData;

            InitializeComponent();
            UIData.ModuleAppliers[index] = true;

            var module = Parent.UIData.Modules[index];
            if (module != null)
            {
                UIData.ExtRate = module.ExtractedVolumePerCycle;
                UIData.CycleTime = module.CycleTime;
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
            var extRate = UIData.ExtRate;
            var cycleTime = UIData.CycleTime;

            for (var i = 0; i < 8; i++)
            {
                if (UIData.ModuleAppliers[i])
                {
                    Parent.UIData.Modules[i] = new MinerModuleData(extRate, cycleTime);
                }
            }

            Parent.Focus();
            Close();
        }

        public class ModuleEditorWindowData : INotifyPropertyChanged
        {
            private double _extRate;
            private double _cycleTime;
            public ObservableCollection<bool> ModuleAppliers { get; set; }

            public ModuleEditorWindowData()
            {
                ModuleAppliers = new ObservableCollection<bool>(new bool[8]);
                ModuleAppliers.CollectionChanged += (sender, args) => Notify("ModuleAppliers");
            }

            public double ExtRate
            {
                get => _extRate;
                set
                {
                    _extRate = value;
                    Notify("ExtRate");
                }
            }

            public double CycleTime
            {
                get => _cycleTime;
                set
                {
                    _cycleTime = value;
                    Notify("CycleTime");
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
