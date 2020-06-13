namespace EveMinerHelperUI
{
    public class TargetAsteroidData
    {
        public int OreAmount;
        public string OreType;

        public TargetAsteroidData(int oreAmount, string oreType)
        {
            OreAmount = oreAmount;
            OreType = oreType;
        }

        public override string ToString()
        {
            return $"{OreAmount} {OreType} ({MainWindowData.GetUnitVolumeForOre(OreType)} m^3)";
        }
    }
}
