using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentsMovement : MonoBehaviour
{
    [SerializeField] Transform TargetTran;
    float Acceleration;
    Vector2 dir;
    // Start is called before the first frame update
    void Start()
    {
        TargetTran = GameCanvasControl.instance.UITexts[1].transform;
        Vector2 pos = new Vector2(TargetTran.position.x, TargetTran.position.y);
        dir = (new Vector2(transform.position.x, transform.position.y) - pos).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 directionForce = dir * -Acceleration;
        transform.position += new Vector3(directionForce.x, directionForce.y) * Time.deltaTime;
        Acceleration += 9.8f * Time.deltaTime * 0.35f;

        if (Vector3.Distance(TargetTran.position, transform.position) <= 0.35f)
        {
            Destroy(gameObject);
            ScoreScale.instance.AddScale();
        }
    }
}
