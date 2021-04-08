using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleResultText : CommonUIText
{
    protected override void Start()
    {
        base.Start();
        UpdateText();
    }

    public override void UpdateText()
    {
        if (manager.instance.GetTimeLeft() <= 0)
        {
            text.text = "Survived!";
            return;
        }
        text.text = "GameOver!";
    }
}
