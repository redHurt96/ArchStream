using UnityEngine;
using Zenject;

namespace _Project.Logic.Tower
{
    public class SpawnController : ITickable
    {
        private readonly EnemiesFactory _factory;
        private float _time = 1f;

        public SpawnController(EnemiesFactory factory) => 
            _factory = factory;

        public void Tick()
        {
            _time = Mathf.Max(_time - Time.deltaTime, 0f);

            if (_time <= 0f)
            {
                _factory.Create();
                _time = 1f;
            }
        }
    }
}