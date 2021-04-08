using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameCanvasControl : SingletonMonoBehavior<GameCanvasControl>
{
    public CommonUIText[] UITexts;

    private void Update()
    {
        UpdateAllText();
    }

     void UpdateAllText()
    {
        foreach (CommonUIText item in UITexts)
        {
            item.UpdateText();
        }
    }


}
