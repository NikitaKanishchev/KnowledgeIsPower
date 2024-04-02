using System;
using System.Collections;
using UnityEngine;

namespace CodeBase.Enemy
{
    [RequireComponent(typeof(EnemyHealth), typeof(EnemyAnimator))]
    public class EnemyDeath : MonoBehaviour
    {
        public EnemyHealth Health;
        public EnemyAnimator Animator;

        public GameObject DeathFX;

        public event Action Happened;

        private void Start() =>
            Health.HealtChanged += HealtChanged;

        private void OnDestroy() =>
            Health.HealtChanged -= HealtChanged;

        private void HealtChanged()
        {
            if (Health.Current <= 0)
                Die();
        }

        private void Die()
        {
            Health.HealtChanged -= HealtChanged;

            Animator.PlayDeath();
            SpawnDeathFX();
            
            StartCoroutine(DestroyTimer());

            Happened?.Invoke();
        }

        private void SpawnDeathFX() =>
            Instantiate(DeathFX, transform.position, Quaternion.identity);

        private IEnumerator DestroyTimer()
        {
            yield return new WaitForSeconds(3);
            Destroy(gameObject);
        }
    }
}