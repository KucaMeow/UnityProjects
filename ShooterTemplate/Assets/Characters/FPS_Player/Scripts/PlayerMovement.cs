using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{    
    private CharacterController cc;
    private Transform t;
    [SerializeField] private float speed = 300;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        t = GetComponent<Transform>();
    }
    void Update()
    {
        Vector3 forward = t.forward;
        Vector3 movement_speed = (
            // Vector3.forward * Input.GetAxis("Vertical") +
            // Vector3.right * Input.GetAxis("Horizontal")
            forward * Input.GetAxis("Vertical") +
            Vector3.Cross(forward, Vector3.up) * Input.GetAxis("Horizontal")
            ) * Time.deltaTime * speed;
        
        cc.SimpleMove(movement_speed);
    }
}
