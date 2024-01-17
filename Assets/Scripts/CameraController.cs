
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject FirstPersonCamera;
    [SerializeField] GameObject ThirdPersonCamera;
    CinemachineVirtualCamera FPCameraComponent;
    CinemachineVirtualCamera TPCameraComponent;
    bool isFirstPerson;
    void Start()
    {
        isFirstPerson = false;
        FPCameraComponent = FirstPersonCamera.GetComponent<CinemachineVirtualCamera>();
        TPCameraComponent = ThirdPersonCamera.GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeCameraFP()
    {
        TPCameraComponent.enabled = false;
        FPCameraComponent.enabled = true;
        isFirstPerson = !isFirstPerson;
        Debug.Log("first persona geçildi");
    }

    public void ChangeCameraTP()
    {
        FPCameraComponent.enabled = false;
        TPCameraComponent.enabled = true;
        isFirstPerson = !isFirstPerson;
        Debug.Log("third persona geçildi");

    }
}
