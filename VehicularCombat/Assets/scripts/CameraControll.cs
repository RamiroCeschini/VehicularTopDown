using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraControll : MonoBehaviour
{
    public CinemachineFreeLook cameraControl;
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            cameraControl.m_XAxis.m_MaxSpeed = 300f;
        }

        else
        {
            cameraControl.m_XAxis.m_MaxSpeed = 0f;
        }

    }
}
