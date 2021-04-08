using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentsSpread : MonoBehaviour
{
    Vector2 CentrePoint;
    Vector2 dir;

    // Start is called before the first frame update
    void Start()
    {
        CentrePoint = transform.position;
        dir = Random.insideUnitCircle;
        Invoke("Switch", Random.Range(0.3f,0.55f));
        Invoke("TurnOff", Random.Range(0.15f,0.3f));
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 Speed = dir * Time.deltaTime * 9.8f * 0.35f;
        transform.position += new Vector3(Speed.x, Speed.y, 0);
    }

    void Switch()
    {
        GetComponent<FragmentsMovement>().enabled = true;
    }

    void TurnOff(){
        enabled = false;
    }
}
