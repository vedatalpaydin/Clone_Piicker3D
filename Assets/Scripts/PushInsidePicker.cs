using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushInsidePicker : MonoBehaviour
{
    private List<GameObject> _objects = new List<GameObject>();

    private void OnTriggerStay(Collider other)
    {
        if (other.tag=="Ball")
        {
            if (_objects.Contains(other.gameObject)) return;
            _objects.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag=="Ball")
        {
            if (_objects.Contains(other.gameObject))
            {
                _objects.Remove(other.gameObject);
            }
        }
    }

    public List<GameObject> GetPickerList()
    {
        return _objects;
    }
}
