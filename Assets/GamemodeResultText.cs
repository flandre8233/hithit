using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamemodeResultText : CommonUIText
{
    protected override void Start()
    {
        base.Start();
        UpdateText();
    }
    public override void UpdateText()
    {
        text.text = GameModeControl.instance.GetGameMode().ToString();
    }
}
