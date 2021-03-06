﻿using Movements;
using UnityEngine;

// ReSharper disable ReplaceWithSingleAssignment.False

namespace Player
{
    [RequireComponent(typeof(AudioSource))]
    public class PlayerFootStepAudioController : MonoBehaviour
    {
        [SerializeField] private Movement playerMovement;
        [SerializeField] private PlayerPlatform platform;
        [SerializeField] private AudioClip waterFootStepClip;
        [SerializeField] private float moveDetectionTolerance = .3f;
        private AudioSource _audioSource;
        private AudioClip _footStepClip;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _footStepClip = _audioSource.clip;
        }

        private void Update()
        {
            var moving = Mathf.Abs(playerMovement.Velocity.x) > moveDetectionTolerance ||
                         Mathf.Abs(playerMovement.Velocity.z) > moveDetectionTolerance;
            if (waterFootStepClip && !platform.CurrentOrLastPlatform)
                _audioSource.clip = waterFootStepClip;
            else _audioSource.clip = _footStepClip;
            switch (moving)
            {
                case true when !_audioSource.isPlaying:
                {
                    _audioSource.Play();
                    break;
                }
                case false:
                    _audioSource.Stop();
                    break;
            }
        }
    }
}