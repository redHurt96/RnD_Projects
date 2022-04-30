using NonEcsComparisonExample.Character.Infrastructure;
using RH.Utilities.Extensions;
using UnityEngine;

namespace NonEcsComparisonExample.Character.Components
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private TeamComponent _teamComponent;

        [Space]
        [SerializeField] private float _current;

        private void Start() => 
            GameData.Instance.Characters.Add(_teamComponent);

        private void OnDestroy() => 
            GameData.Instance?.Characters.Remove(_teamComponent);

        public void TakeDamage(float amount)
        {
            _current = Mathf.Max(0f, _current - amount);

            if (_current.Approximately(0f))
                Die();
        }

        public void Die() => 
            Destroy(gameObject);
    }
}
