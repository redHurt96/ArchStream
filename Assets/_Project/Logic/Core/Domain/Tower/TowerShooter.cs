using UnityEngine;

namespace _Project.Logic.Tower
{
    public class TowerShooter : MonoBehaviour
    {
        [SerializeField] private Arrow _arrow;
        [SerializeField] private float _damage;

        public void SetOrigin(float damage) => 
            _damage = damage;

        public void Shoot(Enemy enemy)
        {
            Vector3 spawnPoint = transform.position + Vector3.up * 2f;
            Vector3 direction = enemy.Position - spawnPoint;
            Arrow instance = Instantiate(_arrow, spawnPoint, Quaternion.identity, transform);
            
            instance.Construct(direction, _damage);
        }
    }
}