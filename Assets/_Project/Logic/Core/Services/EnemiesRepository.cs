using System.Collections.Generic;

namespace _Project.Logic.Tower
{
    public class EnemiesRepository : IEnemiesList, IEnemiesRepositoryWriteOnly
    {
        public IEnumerable<Enemy> All => _all;
        
        private readonly List<Enemy> _all = new();

        public void Register(Enemy enemy) => 
            _all.Add(enemy);

        public void Unregister(Enemy enemy) => 
            _all.Remove(enemy);
    }
}