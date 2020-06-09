namespace EveMinerHelperUI
{
    public class TargetAsteroidData
    {
        public int OreAmount;
        public AsteroidType OreType;
        public bool IsCurrentTarget;

        public TargetAsteroidData(int oreAmount, AsteroidType oreType, bool isCurrentTarget = false)
        {
            OreAmount = oreAmount;
            OreType = oreType;
            IsCurrentTarget = isCurrentTarget;
        }
    }
}
