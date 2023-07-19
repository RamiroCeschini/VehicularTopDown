using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMovement2 : MonoBehaviour
{
    Vector2 turn;
    public float turnSpeed;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        turn.x += Input.GetAxis("Mouse X") * turnSpeed;
        turn.y += Input.GetAxis("Mouse Y") * 0f;
        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0f);
    }
}
