using System.Collections;
using UnityEngine;

namespace NonEcsComparisonExample.Character.Components
{
    public class AttackComponent : MonoBehaviour
    {
        [SerializeField] private float _damage;
        [SerializeField] private float _radius;
        [SerializeField] private float _cooldown;

        [Space] 
        [SerializeField] private FindTargetComponent _findTargetComponent;

        private float _sqrRadius;
        private bool _inCooldown;
        private WaitForSeconds _waitForCooldown;

        private HealthComponent _target => _findTargetComponent.Target;
        private float _sqrDistance => Vector3.SqrMagnitude(_target.transform.position - transform.position);
        private bool _canAttack => _target != null && _sqrDistance < _sqrRadius && !_inCooldown;

        private void Start()
        {
            _sqrRadius = _radius * _radius;
            _waitForCooldown = new WaitForSeconds(_cooldown);
        }

        private void Update()
        {
            if (_canAttack)
            {
                Attack();
                StartCoroutine(Cooldown());
            }
        }

        private void Attack() => 
            _target.TakeDamage(_damage);

        private IEnumerator Cooldown()
        {
            _inCooldown = true;
            yield return _waitForCooldown;
            _inCooldown = false;
        }
    }
}