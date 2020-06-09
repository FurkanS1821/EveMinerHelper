using System.Windows.Controls;

namespace EveMinerHelperUI
{
    public class DoubleProgressBar
    {
        private ProgressBar _bottomBar;
        private ProgressBar _topBar;

        public DoubleProgressBar(ProgressBar bottomBar, ProgressBar topBar)
        {
            _bottomBar = bottomBar;
            _topBar = topBar;
        }

        private double _minimum;
        private double _maximum;

        public double Minimum
        {
            get => _minimum;
            set
            {
                _minimum = value;
                _bottomBar.Minimum = _minimum;
                _topBar.Minimum = _minimum;
            }
        }

        public double Maximum
        {
            get => _maximum;
            set
            {
                _maximum = value;
                _bottomBar.Maximum = _maximum;
                _topBar.Maximum = _maximum;
            }
        }

        public double Value
        {
            get => _topBar.Value;
            set => _topBar.Value = value;
        }

        public double PartialValue
        {
            get => _bottomBar.Value;
            set => _bottomBar.Value = value;
        }
    }
}
