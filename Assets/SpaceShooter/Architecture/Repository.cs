namespace SpaceShooter.Architecture
{
    public abstract class Repository
    {
        public virtual void OnCreate() { }
        public abstract void Initialize();
        public abstract void Save();
        public virtual void OnStart() { }        
    }
}