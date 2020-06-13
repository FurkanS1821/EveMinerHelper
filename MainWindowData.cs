using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace EveMinerHelperUI
{
    public class MainWindowData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private double _totalCargo;
        private double _currentCargo;
        private bool _cargoEnabled = true;
        private int _currentTargetIndex;

        public ObservableCollection<MinerModuleData> Modules = new ObservableCollection<MinerModuleData>();
        public ObservableCollection<TargetAsteroidData> Targets { get; set; } = new ObservableCollection<TargetAsteroidData>();

        public MainWindowData()
        {
            for (var i = 0; i < 8; i++)
            {
                Modules.Add(null);
            }

            Modules.CollectionChanged += (o, args) => Notify("Modules");
            Targets.CollectionChanged += (o, args) => Notify("Targets");
        }

        static MainWindowData()
        {
            OreVolumes = new Dictionary<string, double>
            {
                ["Moon Specific Ores"] = 10,
                ["Arkonor"] = 16,
                ["Bistot"] = 16,
                ["Crokite"] = 16,
                ["Dark Ochre"] = 8,
                ["Gneiss"] = 5,
                ["Hedbergite"] = 3,
                ["Hemorphite"] = 3,
                ["Jaspet"] = 2,
                ["Kernite"] = 1.2,
                ["Mercoxit"] = 40,
                ["Omber"] = 0.6,
                ["Plagioclase"] = 0.35,
                ["Pyroxeres"] = 0.3,
                ["Scordite"] = 0.15,
                ["Spodumain"] = 16,
                ["Veldspar"] = 0.1
            };
        }

        public static Dictionary<string, double> OreVolumes { get; }

        public static double GetUnitVolumeForOre(string type)
        {
            // let it raise a KeyNotFoundException. If that happens, it's my mistake, not user's.
            return OreVolumes[type];
        }

        public double TotalCargo
        {
            get => _totalCargo;
            set
            {
                _totalCargo = value;
                Notify("TotalCargo");
            }
        }

        public double CurrentCargo
        {
            get => _currentCargo;
            set
            {
                _currentCargo = value;
                Notify("CurrentCargo");
            }
        }

        public bool CargoEnabled
        {
            get => _cargoEnabled;
            set
            {
                _cargoEnabled = value;
                Notify("CargoEnabled");
            }
        }

        public int CurrentTargetIndex
        {
            get => _currentTargetIndex;
            set
            {
                _currentTargetIndex = value;
                Notify("CurrentTargetIndex");
            }
        }

        public void Notify(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
