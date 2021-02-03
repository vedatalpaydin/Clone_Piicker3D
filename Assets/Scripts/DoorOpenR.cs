using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DoorOpenR : MonoBehaviour
{ 
    public void ProcessDoorOpenR()
    {
        transform.DORotate(new Vector3(-70, -90, -90), 1.5f);
    }
    public void ProcessCloseDoorR()
    {
        transform.Rotate(0, -90, -90);
    }
}
