using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ComboResultText : MonoBehaviour
{
    [SerializeField] Text text;

    [SerializeField] int CurrentScoreView;
    [SerializeField] int TargetScore;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        text.text = "Combo : " + CurrentScoreView.ToString();

        Invoke("UpdateDelay", 4f);
    }

    void UpdateDelay()
    {
        globalUpdateManager.instance.registerUpdateDg(UpdateScore);
    }

    // Update is called once per frame
    void UpdateScore()
    {
        TargetScore = manager.instance.GetCombo();
        CurrentScoreView = Mathf.RoundToInt(Mathf.Lerp(CurrentScoreView, TargetScore, Time.deltaTime * 3));
        if (CurrentScoreView / TargetScore >= 0.95f)
        {
            CurrentScoreView = TargetScore;
        }
        text.text = "Combo : " + CurrentScoreView.ToString();
    }

    private void OnDestroy()
    {
        globalUpdateManager.instance.UnregisterUpdateDg(UpdateScore);
    }
}
