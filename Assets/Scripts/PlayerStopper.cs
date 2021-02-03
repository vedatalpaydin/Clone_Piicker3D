using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStopper : MonoBehaviour
{
    private bool isTocuhed;
    [SerializeField] private PlayerMovement playerMovement;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="PlayerStopper"&& !isTocuhed)
        {
            playerMovement.SetMoveSpeed(0f);
            isTocuhed = true;
        }
    }
}
