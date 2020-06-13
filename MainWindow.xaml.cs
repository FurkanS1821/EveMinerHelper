using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EveMinerHelperUI
{
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindowData UIData = new MainWindowData();

        public MainWindow()
        {
            DataContext = UIData;
            UIData.PropertyChanged += UIData_PropertyChanged;

            InitializeComponent();

            // OreTypeSelector.ItemsSource = MainWindowData.OreVolumes;
            UIData_PropertyChanged(UIData, new PropertyChangedEventArgs("Modules"));
        }

        private void UIData_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("Modules"))
            {
                var source = new Dictionary<string, MinerModuleData>();
                for (var i = 0; i < 8; i++)
                {
                    var module = UIData.Modules[i];
                    source.Add($"F{i+1}: " + (module == null ? "Empty" : module.ToString()), module);
                }

                ModuleList.ItemsSource = source;
            }
        }

        [Obsolete("Not really obsolete but might be useful later, if ore icons are needed.")]
        public void SetOreIcon(string type)
        {
            // var uri = $"pack://application:,,,/EveMinerHelperUI;component/Resources/Ore_{type.Replace(' ', '_')}.png";
            // SomeComponent.Source = new BitmapImage(new Uri(uri, UriKind.Absolute));
        }

        private void IgnoreCapacityCheck_OnClick(object sender, RoutedEventArgs e)
        {
            UIData.CargoEnabled = IgnoreCapacityCheck.IsChecked != true;
        }

        private void ModuleList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var index = ModuleList.SelectedIndex;
            EditModuleButton.IsEnabled = index >= 0;
            DeleteModuleButton.IsEnabled = index >= 0 && UIData.Modules[index] != null;
        }

        private void EditModuleButton_OnClick(object sender, RoutedEventArgs e)
        {
            var index = ModuleList.SelectedIndex;
            var newWindow = new ModuleEditorWindow(this, index);
            newWindow.Show();
        }

        private void DeleteModuleButton_OnClick(object sender, RoutedEventArgs e)
        {
            var index = ModuleList.SelectedIndex;
            UIData.Modules[index] = null;
        }

        private void TargetList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var index = TargetList.SelectedIndex;
            var isSomethingSelected = index >= 0;
            EditTargetButton.IsEnabled = isSomethingSelected;
            RemoveTargetButton.IsEnabled = isSomethingSelected;
        }

        private void RemoveTargetButton_OnClick(object sender, RoutedEventArgs e)
        {
            UIData.Targets.RemoveAt(UIData.CurrentTargetIndex);
        }

        private void EmptyOreHoldButton_OnClick(object sender, RoutedEventArgs e)
        {
            UIData.CurrentCargo = 0;
        }

        private void AddTargetButton_OnClick(object sender, RoutedEventArgs e)
        {
            var window = new TargetEditorWindow(this);
            window.Show();
            window.Focus();
        }

        private void EditTargetButton_OnClick(object sender, RoutedEventArgs e)
        {
            var window = new TargetEditorWindow(this, (TargetAsteroidData)TargetList.SelectedItem);
            window.Show();
            window.Focus();
        }
    }
}
