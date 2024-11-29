using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.UI.Elements
{
    public class ActorUI : MonoBehaviour
    {
        public HpBar HpBar;
        private IHealth _health;

        public void Construct(IHealth health)
        {
            _health = health;

            _health.HealthChanged += UpdateHPBar;
        }

        private void Start()
        {
            IHealth health = GetComponent<IHealth>();
      
            if(health != null)
                Construct(health);
        }
        
        private void OnDestroy()
        {
            if (_health != null)
                _health.HealthChanged -= UpdateHPBar;
        }

        private void UpdateHPBar()
        {
            HpBar.SetValue(_health.Current, _health.Max);
        }
    }
}