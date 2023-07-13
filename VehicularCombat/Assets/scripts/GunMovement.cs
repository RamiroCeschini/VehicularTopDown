using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMovement : MonoBehaviour
{
   
    public float rotationSpeed = 180f;

    private Transform gunTransform;
    private Camera mainCamera;

    private void Awake()
    {
        gunTransform = GetComponent<Transform>();
        mainCamera = Camera.main;
    }

    private void Update()
    {


        // Rotation
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 targetPosition = new Vector3(hit.point.x, gunTransform.position.y, hit.point.z);
            Vector3 direction = targetPosition - gunTransform.position;

            if (direction != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(direction);
                gunTransform.rotation = Quaternion.RotateTowards(gunTransform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }

}
