using _Project.Logic.Tower;
using UnityEngine;

namespace _Project.Logic.Core.Controllers
{
    internal class HitEffectController : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private HitEffect _hitEffect;

        private void Start() => 
            _health.Changed += _hitEffect.Show;

        private void OnDestroy() => 
            _health.Changed -= _hitEffect.Show;

    }
}