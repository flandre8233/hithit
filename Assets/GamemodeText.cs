using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamemodeText : CommonUIText
{
    public override void UpdateText()
    {
        text.text = GameModeControl.instance.GetGameMode().ToString();
    }
}
