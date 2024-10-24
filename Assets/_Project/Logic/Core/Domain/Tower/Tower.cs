using System;
using _Project.Logic.Common.Domain;
using _Project.Logic.Core.Controllers;
using UnityEngine;
using Zenject;

namespace _Project.Logic.Tower
{
    public class TowerInstaller2 : MonoInstaller
    {
        [SerializeField] private StatView _statView;
        [SerializeField] private Health _health;

        public override void InstallBindings() => 
            Container.BindInterfacesTo<HealthViewPresenter>().AsSingle().WithArguments(_health, _statView);
    }
    
    public class TowerInstaller : MonoBehaviour
    {
        [SerializeField] private StatView _statView;
        [SerializeField] private Health _health;
        
        private HealthViewPresenter _healthViewPresenter;

        private void Awake() => 
            _healthViewPresenter = new(_health, _statView);

        private void Start() => 
            _healthViewPresenter.Initialize();

        private void OnDestroy() => 
            _healthViewPresenter.Dispose();
    }
    public class Tower : MonoBehaviour
    {
        public event Action Dead;
        
        public Vector3 Position => transform.position;
        
        private IEnemiesList _enemiesRepository;
        private bool InCooldown => _currentCooldown > 0f;

        [SerializeField] private float _shootDistance;
        [SerializeField] private float _cooldownTime;
        [SerializeField] private float _currentCooldown;
        [SerializeField] private TowerShooter _towerShooter;
        private Health _health;

        [Inject]
        private void Construct(IEnemiesList enemiesRepository, TowerData towerData)
        {
            _enemiesRepository = enemiesRepository;
            _health.SetOrigin(towerData.Health);
            _towerShooter.SetOrigin(towerData.Damage);
        }

        private void Start() => 
            _health.Dead += Die;

        private void OnDestroy() => 
            _health.Dead -= Die;

        private void Update()
        {
            _currentCooldown = Mathf.Max(_currentCooldown - Time.deltaTime, 0f);
            
            foreach (Enemy enemy in _enemiesRepository.All)
            {
                if (CloseToShoot(enemy) && !InCooldown)
                    Shoot(enemy);
            }
        }

        private bool CloseToShoot(Enemy enemy) => 
            Vector3.Distance(enemy.Position, Position) < _shootDistance;

        private void Shoot(Enemy enemy)
        {
            _towerShooter.Shoot(enemy);
            _currentCooldown = _cooldownTime;
        }

        public void Hit(float damage) => 
            _health.Decrease(damage);

        private void Die() => 
            Dead?.Invoke();
    }
}
