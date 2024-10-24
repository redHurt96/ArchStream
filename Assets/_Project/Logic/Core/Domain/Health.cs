using System;
using UnityEngine;

namespace _Project.Logic.Tower
{
    public class Health : MonoBehaviour
    {
        public event Action Changed;
        public event Action Dead;
        
        [field:SerializeField] public float Max;
        [field:SerializeField] public float Current;

        public void SetOrigin(float towerDataHealth)
        {
            Max = towerDataHealth;
            Current = Max;
        }

        public void Decrease(float damage)
        {
            Current = Mathf.Max(Current - damage, 0f);
            
            Changed?.Invoke();

            if (Mathf.Approximately(Current, 0f))
                Dead?.Invoke();
        }
    }
}