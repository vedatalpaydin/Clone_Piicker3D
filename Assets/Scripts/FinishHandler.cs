using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishHandler : MonoBehaviour
{
    [SerializeField] private FailedHandler finishCanvas;
    [SerializeField] private GameObject startPoint;
    [SerializeField] private PlayerMovement _playerMovement;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="PlayerStopper")
        {
            finishCanvas.FinishCanvas();
            startPoint.SetActive(true);
            _playerMovement.enabled = false;
        }
    }
}
