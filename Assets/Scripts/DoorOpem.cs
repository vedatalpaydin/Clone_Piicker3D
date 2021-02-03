using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DoorOpem : MonoBehaviour
{ 
    public void ProcessOpenDoor()
    {
        transform.DORotate(new Vector3(70, -90, -90), 1.5f);
    }

    public void ProcessCloseDoor()
    {
        transform.Rotate(0, -90, -90);
    }
}
