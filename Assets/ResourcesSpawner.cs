using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesSpawner : MonoBehaviour
{

    public static GameObject Spawn(string FileName)
    {
        GameObject BGMPrefab = Resources.Load<GameObject>(FileName);
        return Instantiate(BGMPrefab, new Vector3(), Quaternion.identity);
    }

    public static void DestroySomething(GameObject Something)
    {
        Destroy(Something, 0.5f);
    }
}
