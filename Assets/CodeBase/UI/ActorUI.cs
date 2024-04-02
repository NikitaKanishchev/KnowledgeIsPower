using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.UI
{
    public class ActorUI : MonoBehaviour
    {
        public HpBar HpBar;
        private IHealth _health;

        public void Construct(IHealth health)
        {
            _health = health;

            _health.HealtChanged += UpdateHPBar;
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
                _health.HealtChanged -= UpdateHPBar;
        }

        private void UpdateHPBar()
        {
            HpBar.SetValue(_health.Current, _health.Max);
        }
    }
}