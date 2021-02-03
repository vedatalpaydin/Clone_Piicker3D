using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ElevatorUp : MonoBehaviour
{
    public void ProcessElevatorUp()
    {
        transform.DOMoveY(0, 1f);
    }

    public void ProcessElevatorDown()
    {
        transform.position = new Vector3(0, -3f);
    }
}
