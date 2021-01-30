﻿using Player;
using UnityEngine;

namespace Puzzle
{
    [RequireComponent(typeof(BoxCollider))]
    [RequireComponent(typeof(DoorAuthoring))]
    public class PlatformTrigger:MonoBehaviour
    {
        private BoxCollider _collider;
        private DoorAuthoring _doorMode;
        private PlayerPlatform _player;
        private PlatformAuthoring _platformAuthoring;


        private void Awake()
        {
            _doorMode = GetComponent<DoorAuthoring>();
            _collider = GetComponent<BoxCollider>();
            _platformAuthoring = GetComponent<PlatformAuthoring>();
            _collider.isTrigger = true;
            _player = FindObjectOfType<PlayerPlatform>();
        }

        private void Update()
        {
            var doorModeIsOpen = _collider.bounds.Contains(_player.transform.position);
            _doorMode.IsOpen = doorModeIsOpen;
            if (doorModeIsOpen) _player.CurrentOrLastPlatform = _platformAuthoring;
        }
    }
}