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

    public Text gameModeText;

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


        switch (backgroundScript.Static.gameMode)
        {
            case "timeAttack":
                gameStartTimeLeft.gameObject.SetActive(true);
                gameModeText.text = backgroundScript.Static.gameMode;
                break;
            case "infinite":
                gameStartTimeLeft.gameObject.SetActive(false);
                gameModeText.text = backgroundScript.Static.gameMode;
                break;
            case "songTimeAttck":
                gameStartTimeLeft.gameObject.SetActive(true);
                gameModeText.text = backgroundScript.Static.gameMode;
                break;
            default:
                gameStartTimeLeft.gameObject.SetActive(true);
                gameModeText.text = "timeAttack";
                break;
        }
    }

    public void updateText(int scoreInt,int comboInt, float gameStartTimeLeftInt)
    {
        score.text = "Score : " + scoreInt;
        combo.text = "combo : " + comboInt;
        gameStartTimeLeft.text = "" + System.Math.Round( gameStartTimeLeftInt,2);
        gameStartTimeLeft.color = Color.Lerp(Color.red, Color.black, gameStartTimeLeftInt*(1.0f/30.0f) );
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
        SceneManager.LoadScene(1);
    }

    public void backToMenuButton()
    {
        SceneManager.LoadScene(0);
    }

}
