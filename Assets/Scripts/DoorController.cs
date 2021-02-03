using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private DoorOpem _doorOpem;
    [SerializeField] private DoorOpenR _doorOpenR;
    [SerializeField] private PlayerMovement playerMovement;
    public void OpenTheLeftDoor()
    {
        _doorOpem.ProcessOpenDoor();
    }

    public void OpenTheRightDoor()
    {
        _doorOpenR.ProcessDoorOpenR();
        playerMovement.SetMoveSpeed(7f);
    }

    public void CloseLeftDoor()
    {
        _doorOpem.ProcessCloseDoor();
    }
    public void CloseRightDoor()
    {
        _doorOpenR.ProcessCloseDoorR();
    }
}
