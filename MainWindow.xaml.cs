using System;
using System.Collections.Generic;
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
        public DoubleProgressBar OreHoldIndicator;
        public TargetAsteroidData[] Targets = new TargetAsteroidData[15]; // Maximum possible targets in the game is 15
        public MinerModuleData[] Modules = new MinerModuleData[8]; // Maximum amount of high-power fit slots is 8
        public MainWindow()
        {
            OreHoldIndicator = new DoubleProgressBar(BottomProgressBar, TopProgressBar);
            InitializeComponent();
        }
    }
}
