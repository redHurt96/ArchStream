using System;
using UnityEngine;

namespace _Project.Logic.Tower
{
    internal class Arrow : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _speed;
        
        private float _damage;
        private Vector3 _direction;

        public void Construct(Vector3 direction, float damage)
        {
            _direction = direction;
            _damage = damage;
        }

        private void Start()
        {
            _rigidbody.velocity = _direction * _speed;
            Destroy(gameObject, 5f);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out Enemy enemy))
            {
                enemy.Hit(_damage);
                Destroy(gameObject);
            }
        }
    }
}