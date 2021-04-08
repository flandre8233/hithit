using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerAniControl : MonoBehaviour
{
    public void Exp()
    {
        GetComponent<Animator>().enabled = true;
    }
}
