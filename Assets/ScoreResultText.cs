using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreResultText : MonoBehaviour
{
    [SerializeField] Text text;

    [SerializeField] int CurrentScoreView;
    [SerializeField] int TargetScore;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        text.text = "Score : " + CurrentScoreView.ToString();

        Invoke("UpdateDelay", 3f);
    }

    void UpdateDelay()
    {
        globalUpdateManager.instance.registerUpdateDg(UpdateScore);
    }

    // Update is called once per frame
    void UpdateScore()
    {
        TargetScore = manager.instance.GetScore();
        CurrentScoreView = Mathf.RoundToInt(Mathf.Lerp(CurrentScoreView, TargetScore, Time.deltaTime * 3));
        if (TargetScore <= 0)
        {
            CurrentScoreView = 0;
        }
        else
        if (CurrentScoreView / TargetScore >= 0.95f)
        {
            CurrentScoreView = TargetScore;
        }
        text.text = "Score : " + CurrentScoreView.ToString();
    }

    private void OnDestroy()
    {
        globalUpdateManager.instance.UnregisterUpdateDg(UpdateScore);
    }
}
