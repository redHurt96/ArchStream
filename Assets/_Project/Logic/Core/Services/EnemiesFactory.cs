using UnityEngine;

namespace _Project.Logic.Tower
{
    public class EnemiesFactory
    {
        private readonly IEnemiesRepositoryWriteOnly _repository;
        private readonly Enemy _prefab;
        private readonly Tower _tower;
        private readonly Transform _parent;

        public EnemiesFactory(IEnemiesRepositoryWriteOnly repository, Enemy prefab, Tower tower, Transform parent)
        {
            _repository = repository;
            _prefab = prefab;
            _tower = tower;
            _parent = parent;
        }

        public void Create()
        {
            Vector3 position = new(
                Random.Range(-20f, 20f),
                1f,
                Random.Range(-20f, 20f));
            Enemy instance = Object.Instantiate(_prefab, position, Quaternion.identity, _parent);
            
            instance.Initialize(_tower);
            _repository.Register(instance);

            instance.OnDead += Unregister;

            void Unregister()
            {
                instance.OnDead -= Unregister;
                _repository.Unregister(instance);
            }
        }
    }
}