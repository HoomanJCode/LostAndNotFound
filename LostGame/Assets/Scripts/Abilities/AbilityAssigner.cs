﻿using System;
using Player;
using UnityEngine;

namespace Abilities
{
    public sealed class AbilityAssigner : MonoBehaviour
    {
        [SerializeField] private float distanceToAssignToPlayer = 1f;
        [SerializeField] private bool autoDisable = true;
        private PlayerAuthoring _player;
        public event Action<GameObject> OnPlayerEnter;

        private void Awake()
        {
            _player=FindObjectOfType<PlayerAuthoring>();
            if (_player) return;
            Debug.LogWarning($"{name} Can Not Find Player!");
            enabled = false;
        }

        private void Update()
        {
            // ReSharper disable once InvertIf
            if (Vector3.Distance(_player.transform.position, transform.position) < distanceToAssignToPlayer)
            {
                OnPlayerEnter?.Invoke(_player.gameObject);
                if(autoDisable) enabled = false;
            }
        }
        
    }
}