using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ResetListener : SingletonMonoBehavior<ResetListener>
{

    private void Start()
    {
        Invoke("StartListen", 1f);
    }

    private void StartListen()
    {
        globalUpdateManager.instance.registerUpdateDg(ResetInputListener);
    }
    void ResetInputListener()
    {
        if (Input.GetMouseButtonUp(0))
        {
            resetScene();
        }
    }

    public void resetScene()
    {
        globalUpdateManager.instance.UnregisterUpdateDg(ResetInputListener);
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    private void OnDestroy()
    {
        globalUpdateManager.instance.UnregisterUpdateDg(ResetInputListener);
    }
}
