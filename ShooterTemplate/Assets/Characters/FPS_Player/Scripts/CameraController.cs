using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerTransorm;
    [SerializeField] private float sensetivity = 100;
    private Transform cameraTransform;
    private float xAxis;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        xAxis = 0f;
    }
    void Start()
    {
        cameraTransform = GetComponent<Transform>();
    }
    void Update()
    {
        //horisontal rotation
        float mouseX = Input.GetAxis("Mouse X") * sensetivity * Time.deltaTime;
        var rotation = playerTransorm.eulerAngles;
        rotation.y += mouseX;
        playerTransorm.eulerAngles = rotation;
        
        //vertical rotation
        float mouseY = Input.GetAxis("Mouse Y") * sensetivity * Time.deltaTime;
        xAxis += mouseY;

        if(xAxis > 90f)
        {
            xAxis = 90f;
            mouseY = 0f;
            setVertRotation(270f);
        }
        else if(xAxis < -90f)
        {
            xAxis = -90f;
            mouseY = 0f;
            setVertRotation(90f);
        }

        cameraTransform.Rotate(Vector3.left * mouseY);
    }

    private void setVertRotation (float angle)
    {
        Vector3 eulerRot = cameraTransform.eulerAngles;
        eulerRot.x = angle;
        transform.eulerAngles = eulerRot;
    }
}
