using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace NonEcsComparisonExample.Character.Components
{
    public class MoveToTargetComponent : MonoBehaviour
    {
        [SerializeField] private FindTargetComponent _findTargetComponent;
        [SerializeField] private NavMeshAgent _navMeshAgent;

        [Space]
        [SerializeField] private float _cooldownTime;

        private bool _inCooldown;
        private WaitForSeconds _waitForCooldown;

        private HealthComponent _target => _findTargetComponent.Target;

        private void Start()
        {
            _waitForCooldown = new WaitForSeconds(_cooldownTime);
        }

        private void Update()
        {
            if (_target != null && !_inCooldown)
            {
                _navMeshAgent.SetDestination(_target.transform.position);
                StartCoroutine(GoInCooldown());
            }
        }

        private IEnumerator GoInCooldown()
        {
            _inCooldown = true;
            yield return _waitForCooldown;
            _inCooldown = false;
        }
    }
}