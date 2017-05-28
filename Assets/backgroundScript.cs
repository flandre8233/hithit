using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundScript : MonoBehaviour {
    public static backgroundScript Static;

    public string gameMode = "";



    private void Awake()
    {
        if (Static != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Static = this;
        }

        DontDestroyOnLoad(transform.gameObject);
    }
}
