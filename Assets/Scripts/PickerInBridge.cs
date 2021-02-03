using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickerInBridge : MonoBehaviour
{
    [SerializeField] private NextLevelLoad _nextLevelLoad;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="PlayerStopper")
        {
            _nextLevelLoad.SetProcessNextLevel(true);
        }
    }
}
