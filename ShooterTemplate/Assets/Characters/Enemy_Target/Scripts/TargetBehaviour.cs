using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehaviour : MonoBehaviour
{
    private int HP = 10;
    private Transform playerTr;
    void Start()
    {
        playerTr = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Debug.Log(GameObject.FindGameObjectWithTag("Player").name);
    }
    void Update()
    {
        GetComponent<Transform>().LookAt(playerTr);
    }

    public void hitEvent()
    {
        if (HP > 0)
        {
            HP--;
            Debug.Log(HP);
        }
        else
        {
            Debug.Log("Target should die");
            Destroy(this.gameObject);
        }
    }
}
