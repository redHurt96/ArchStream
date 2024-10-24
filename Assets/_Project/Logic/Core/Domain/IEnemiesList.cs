using System.Collections.Generic;

namespace _Project.Logic.Tower
{
    public interface IEnemiesList
    {
        IEnumerable<Enemy> All { get; }
    }
}