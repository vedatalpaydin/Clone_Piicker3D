using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelLoad : MonoBehaviour
{
    [SerializeField] private GameObject picker;
   
    
    private CollectorPool collectorPool;
    private DoorController gates;
    private ElevatorUp elevator;
    

    
    private bool ProcessNextLevel;

    private void Awake()
    {
        collectorPool = FindObjectOfType<CollectorPool>();
        gates = FindObjectOfType<DoorController>();
        elevator = FindObjectOfType<ElevatorUp>();
    }

    private void Update()
    {
        if (ProcessNextLevel)
        {
            ProcessPickerSpawnStartPoint();
            ProcessCollectorPoolReset();
            ProcessDoorClosed();
            ProcessElevatorDown();
        }
    }

    private void ProcessElevatorDown()
    {
        elevator.ProcessElevatorDown();
    }

    private void ProcessDoorClosed()
    {
        gates.CloseLeftDoor();
        gates.CloseRightDoor();
    }

    private void ProcessCollectorPoolReset()
    {
        collectorPool.CollectorPoolForNextLevel();
    }

    private void ProcessPickerSpawnStartPoint()
    {
        picker.transform.position = new Vector3(0, 0, -36f);
        picker.transform.localScale = new Vector3(1, 1, 1);
        picker.GetComponent<PlayerMovement>().ProcessPickerMoveForward();
    }

    public bool SetProcessNextLevel(bool startProcess)
    {
        return ProcessNextLevel = startProcess;
    }
}
