using System;
using UnityEngine;

namespace NonEcsComparisonExample.Character.Infrastructure
{
    public class EntryPoint : MonoBehaviour
    {
        private void Awake()
        {
            new GameData();
        }

        private void OnDestroy()
        {
            GameData.DestroyInstance();
        }
    }
}