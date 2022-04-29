using System;
using NonEcsComparisonExample.Character.Infrastructure;
using UnityEngine;

namespace NonEcsComparisonExample.Character.Components
{
    public class FindTargetComponent : MonoBehaviour
    {
        public HealthComponent Target { get; private set; }

        [SerializeField] private TeamComponent _teamComponent;

        private void Update()
        {
            if (Target == null)
                FindTarget();
        }

        private void FindTarget()
        {
            (TeamComponent team, float sqrDistance) closestEnemy = new ValueTuple<TeamComponent, float>(null, float.MaxValue);

            foreach (TeamComponent member in GameData.Instance.Characters)
            {
                if (member.Team != _teamComponent.Team)
                {
                    float distanceSqr = Vector3.SqrMagnitude(member.transform.position - transform.position);

                    if (distanceSqr < closestEnemy.sqrDistance)
                        closestEnemy = (member, distanceSqr);
                }
            }

            if (closestEnemy.team != null)
                Target = closestEnemy.team.GetComponent<HealthComponent>();
        }
    }
}