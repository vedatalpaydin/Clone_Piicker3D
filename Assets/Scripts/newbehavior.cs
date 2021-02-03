using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class newbehavior : MonoBehaviour
{
    void Start()
    {
        transform.DORotate(new Vector3(150, 0, 0), 5f);
    }

}
