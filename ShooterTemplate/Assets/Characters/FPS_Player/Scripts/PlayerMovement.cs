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
        Vector3 movement_speed = (
            t.forward * Input.GetAxis("Vertical") +
            t.right * Input.GetAxis("Horizontal")
            ) * Time.deltaTime * speed;
        
        cc.SimpleMove(movement_speed);
    }
}
