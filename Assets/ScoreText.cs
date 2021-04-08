using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreText : CommonUIText
{
    public override void UpdateText()
    {
        text.text = manager.instance.GetScore().ToString();
    }
}
