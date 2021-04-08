using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocker : MonoBehaviour
{
    public void ExitDelay(float DelayTime)
    {
        Invoke("Exit", DelayTime);
    }
     void Exit()
    {
        GetComponentInChildren<Animator>().SetTrigger("Exit");
        Destroy(gameObject, 3f);
    }
}
