using System;
using _Project.Logic.Tower;
using Zenject;

namespace _Project.Logic.Core.Controllers
{
    public class HealthViewPresenter : IInitializable, IDisposable
    {
        private readonly Health _health;
        private readonly StatView _statView;

        public HealthViewPresenter(Health health, StatView statView)
        {
            _health = health;
            _statView = statView;
        }

        public void Initialize() =>
            _health.Changed += UpdateView;

        public void Dispose() =>
            _health.Changed -= UpdateView;

        private void UpdateView()
        {
            float value = _health.Current / _health.Max;
            _statView.Draw(value);
        }
    }
}