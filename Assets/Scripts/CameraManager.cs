using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    CameraController cameraController;
    // Start is called before the first frame update
    void Start()
    {
        cameraController = GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CameraFPTriggerEntered()
    {
        cameraController.ChangeCameraFP();
        Debug.Log("CameraFPTriggerEntered çalıştı");
    }

    public void CameraTPTriggerEntered()
    {
        cameraController.ChangeCameraTP();
        Debug.Log("CameraTPTriggerEntered çalıştı");
    }
}
