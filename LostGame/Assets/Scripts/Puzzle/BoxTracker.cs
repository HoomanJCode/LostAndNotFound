﻿using UnityEngine;

namespace Puzzle
{
    public class BoxTracker : MonoBehaviour
    {
        [SerializeField] private float radiusToDetectBox = 1f;
        [SerializeField] private DoorAuthoring targetDoor;
        [SerializeField] private BoxAuthoring box;
        [SerializeField] private Vector3 offset;

        private void Update()
        {
            //box is in place
            targetDoor.IsOpen = Vector3.Distance(box.transform.position, transform.position+offset) < radiusToDetectBox;
        }
        
    }
}