using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class pointHit : MonoBehaviour
{
    public LayerMask mask;
    void Update()
    {
        if (manager.Static.inGameover)
        {
            return;
        }


        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                // Construct a ray from the current touch coordinates
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                // Create a particle if hit
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100.0f, mask) && hit.collider.tag == "hitBlock")
                {
                    manager.Static.button(hit.collider.gameObject.GetComponent<hitblockClass>().hitNumber);
                }
            }
        }

    }
}
