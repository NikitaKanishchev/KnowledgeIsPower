using System.Collections;
using UnityEngine;

namespace CodeBase.Enemy
{
    public class Aggro : MonoBehaviour
    {
        public TriggerObserver TriggerObserver;
        public AgentMoveToPlayer Follow;

        public float Cooldown;

        private Coroutine _aggroCoroutie;
        private bool _hasAggroTarget;

        private void Start()
        {
            TriggerObserver.TriggerEnter += TriggerEnter;
            TriggerObserver.TriggerExit += TriggerExit;

            SwitchFollowOff();
        }

        private void TriggerEnter(Collider obj)
        {
            if (!_hasAggroTarget)
            {
                _hasAggroTarget = true;
                
                StopAggroCoroutine();

                SwitchFollowOn();
            }
        }

        private void TriggerExit(Collider obj)
        {
            if (_hasAggroTarget)
            {
                _hasAggroTarget = false;
                _aggroCoroutie = StartCoroutine(SwitchFollowOffAfterCooldown());
            }
        }

        private IEnumerator SwitchFollowOffAfterCooldown()
        {
            yield return new WaitForSeconds(Cooldown);

            SwitchFollowOff();
        }

        private void StopAggroCoroutine()
        {
            if (_aggroCoroutie != null)
            {
                StopCoroutine(_aggroCoroutie);
                _aggroCoroutie = null;
            }
        }

        private void SwitchFollowOn()
        {
            Follow.enabled = true;
        }

        private void SwitchFollowOff()
        {
            Follow.enabled = false;
        }
    }
}