namespace _Project.Logic.Tower
{
    public interface IEnemiesRepositoryWriteOnly
    {
        void Register(Enemy enemy);
        void Unregister(Enemy enemy);
    }
}