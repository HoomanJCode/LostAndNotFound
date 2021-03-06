﻿using UnityEngine;

// ReSharper disable Unity.InefficientPropertyAccess

namespace Puzzle
{
    public class PlatformAuthoring : MonoBehaviour
    {
        private PlatformManagerAuthoring _managerAuthoring;

        public Transform RespawnPoint => _managerAuthoring.respawnPoint;

        private void Awake()
        {
            _managerAuthoring = GetComponentInParent<PlatformManagerAuthoring>();
        }

        public void RePlacePlatform()
        {
            var gm = Instantiate(_managerAuthoring.platformPrefab.gameObject, transform.parent);
            gm.transform.position = transform.position;
            gm.transform.rotation = transform.rotation;
            gm.GetComponent<PlatformAuthoring>()._managerAuthoring = _managerAuthoring;
            Destroy(gameObject);
        }
    }
}