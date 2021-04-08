using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentsDestoryer : MonoBehaviour
{
private void OnEnable() {
    GameObject[] Fragments = GameObject.FindGameObjectsWithTag("Fragments");
        foreach (var item in Fragments)
        {
            Destroy(item);
        }
}
}
