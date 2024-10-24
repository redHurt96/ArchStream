using DG.Tweening;
using UnityEngine;

namespace _Project.Logic.Core.Controllers
{
    internal class HitEffect : MonoBehaviour
    {
        [SerializeField] private Renderer _renderer;
        
        private Tween _tween;

        internal void Show()
        {
            if (_tween?.IsPlaying() ?? false)
                return;
            
            _tween = _renderer.material
                .DOColor(Color.red, .5f)
                .SetLoops(2, LoopType.Yoyo);
        }
    }
}