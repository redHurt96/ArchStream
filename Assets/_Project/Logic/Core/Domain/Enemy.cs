using System;
using UnityEngine;
using UnityEngine.AI;

namespace _Project.Logic.Tower
{
    public class Enemy : MonoBehaviour
    {
        public event Action OnDead;
        
        public Vector3 Position => transform.position;
        private bool CloseToTower => Vector3.Distance(Position, _tower.Position) < _attackDistance;
        private bool InCooldown => _cooldown > 0f;

        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private Health _health;
        [SerializeField] private float _attackDistance;
        [SerializeField] private float _attackCooldown;
        [SerializeField] private float _damage;

        private Tower _tower;
        private float _cooldown;

        public void Initialize(Tower tower) => 
            _tower = tower;

        private void Start()
        {
            _agent.SetDestination(_tower.Position);
            _health.Dead += Die;
        }

        private void OnDestroy() => 
            _health.Dead -= Die;

        private void Update()
        {
            if (CloseToTower && !InCooldown)
            {
                Attack();
                _cooldown = _attackCooldown;
            }
        }

        public void Hit(float damage) => 
            _health.Decrease(damage);

        private void Attack() => 
            _tower.Hit(_damage);

        private void Die()
        {
            OnDead?.Invoke();
            Destroy(gameObject);
        }
    }
}