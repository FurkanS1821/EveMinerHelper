namespace EveMinerHelperUI
{
    public class MinerModuleData
    {
        public double ExtractedVolumePerCycle;
        public double CycleTime;

        public MinerModuleData(double extractRate, double cycleTime)
        {
            ExtractedVolumePerCycle = extractRate;
            CycleTime = cycleTime;
        }

        public override string ToString()
        {
            return $"{ExtractedVolumePerCycle} m^3 in {CycleTime}s";
        }
    }
}
