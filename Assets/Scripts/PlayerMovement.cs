using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 300f;
    [SerializeField] private float horizontalSpeed = 5f;
    [SerializeField] private PushInsidePicker _pushInsidePicker;
    [SerializeField] private Canvas startCanvas;
    private Rigidbody rb;
    private Vector3 movement;
    private bool canPickerMove;
    private Vector2 lastMousePos;

    void Start()
    {
        startCanvas.enabled = true;
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePos = Input.mousePosition;
            canPickerMove = true;
        }
        if (canPickerMove)
        {
            startCanvas.enabled = false;
            if (Input.GetMouseButton(0))
            {
                Vector2 currentMousePos = Input.mousePosition;
                Vector2 delta = currentMousePos - lastMousePos;
                lastMousePos = currentMousePos;
                movement = new Vector3(delta.x*Time.deltaTime*horizontalSpeed, 0, 0);
                movement.x = Mathf.Clamp(movement.x, -horizontalSpeed, horizontalSpeed);
                rb.velocity = movement;
            }

            if (Input.GetMouseButtonUp(0))
            {
                rb.velocity = Vector3.zero;
            }
            if (canPickerMove)
            {
                ProcessPickerMoveForward();
            }

            if (moveSpeed<=0)
            {
                var insidePicker= _pushInsidePicker.GetPickerList();
                if (insidePicker==null) return;
                foreach (GameObject balls in insidePicker)
                {
                    balls.GetComponent<Rigidbody>().AddForce(0f,0f,100f);
                }
                insidePicker.Clear();
            }
        }
        //transform.position = new Vector3(Mathf.Clamp(transform.position.x, -1.85f, 1.85f),transform.position.y,transform.position.z);
    }

    public void ProcessPickerMoveForward()
    {
        if (Input.GetMouseButton(0))
        {
            rb.velocity = new Vector3(rb.velocity.x, 0f, moveSpeed);
        }
        else
        {
            rb.velocity = new Vector3(0f, 0f, moveSpeed);

        }
        
        
    }
    public float SetMoveSpeed(float speed)
    {
        return moveSpeed = speed;
    }

    public bool SetCanPickerMove(bool move)
    {
        return canPickerMove = move;
    }
}
