using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private Object hitSphere;
    void Start()
    {
        cam = GetComponent<Camera>();
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) 
        {
            Vector3 center = new Vector3 (cam.pixelWidth/2, cam.pixelHeight/2, 0);
            Ray shootRay = cam.ScreenPointToRay(center);
            RaycastHit hit;
            if  (Physics.Raycast(shootRay, out hit))
            {
                GameObject hitObj = hit.transform.gameObject;
                TargetBehaviour tb = hitObj.GetComponent<TargetBehaviour>();
                if  (tb != null)
                {
                    tb.hitEvent();
                }
                else
                {
                    StartCoroutine(spawnSphere(hit.point));
                }
            }
        }
    }

    private IEnumerator spawnSphere (Vector3 pos)
    {
        GameObject sphere = GameObject.Instantiate((GameObject)hitSphere);
        sphere.transform.position = pos;
        yield return new WaitForSeconds(1);
        Destroy(sphere);
    }
}
