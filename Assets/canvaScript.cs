using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class canvaScript : MonoBehaviour {
    public static canvaScript Static;

    public Text score;
    public Text combo;
    public Text gameStartTimeLeft;

    public GameObject gameover;

    private void Awake()
    {
        if (Static != null)
        {
            Destroy(this);
        }
        else
        {
            Static = this;
        }
    }

    public void updateText(int scoreInt,int comboInt, float gameStartTimeLeftInt)
    {
        score.text = "Score : " + scoreInt;
        combo.text = "combo : " + comboInt;
        gameStartTimeLeft.text = "" + gameStartTimeLeftInt;
    }

    public void goGameover()
    {
        manager.Static.inGameover = true;
        score.color = Color.white;
        combo.color = Color.white;
        gameStartTimeLeft.gameObject.SetActive(false);
        gameover.SetActive(true);
    }

    public void resetButton()
    {
        SceneManager.LoadScene(0);
    }

}
