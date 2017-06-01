using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menuCanvasScript : MonoBehaviour {

    public void timeAttackButton()
    {
        backgroundScript.Static.gameMode = "timeAttack";
        SceneManager.LoadScene("aa");
    }
    public void infiniteButton()
    {
        backgroundScript.Static.gameMode = "infinite";
        SceneManager.LoadScene("aa");
    }
    public void SongTimeAttackButton()
    {
        backgroundScript.Static.gameMode = "songTimeAttck";
        SceneManager.LoadScene("aa");
    }
}
