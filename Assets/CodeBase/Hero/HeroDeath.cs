﻿using UnityEngine;

namespace CodeBase.Hero
{
    [RequireComponent(typeof(HeroHealth))]
    public class HeroDeath : MonoBehaviour
    {
        public HeroHealth Health;

        public HeroMove Move;
        public HeroAttack Attack;
        public HeroAnimator Animator;

        public GameObject DeathFx;
        private bool _isDead;

        private void Start() =>
            Health.HealthChanged += HelthChanged;

        private void OnDestroy() =>
            Health.HealthChanged -= HelthChanged;

        private void HelthChanged()
        {
            if (!_isDead && Health.Current <= 0)
                Die();
        }

        private void Die()
        {
            _isDead = true;
            
            Move.enabled = false;
            Attack.enabled = false;
            Animator.PlayDeath();

            Instantiate(DeathFx, transform.position, Quaternion.identity);
        }
    }
}