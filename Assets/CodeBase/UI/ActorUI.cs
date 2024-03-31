using CodeBase.Hero;
using UnityEngine;

namespace CodeBase.UI
{
    public class ActorUI : MonoBehaviour
    {
        public HPBar HpBar;
        private HeroHealth _heroHealth;

        public void Construct(HeroHealth health)
        {
            _heroHealth = health;

            _heroHealth.HelthChanged += UpdateHPBar;
        }

        private void OnDestroy()
        {
            if (_heroHealth != null)
                _heroHealth.HelthChanged -= UpdateHPBar;
        }

        private void UpdateHPBar()
        {
            HpBar.SetValue(_heroHealth.Current, _heroHealth.Max);
        }
    }
}