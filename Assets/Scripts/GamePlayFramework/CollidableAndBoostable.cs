using DataBases;

namespace GamePlayFramework
{
    public abstract class CollidableAndBoostable : Collidable
    {
        public abstract void ApplyBoosterEffect(BoosterEffect boosterEffect);
    }
}