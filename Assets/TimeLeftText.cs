using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLeftText : CommonUIText
{
    public override void UpdateText()
    {
        float TimeLeft = manager.instance.GetTimeLeft();
        text.text = System.Math.Round(TimeLeft, 2).ToString();
        text.color = Color.Lerp(Color.red, Color.black, TimeLeft * (1.0f / 45.0f));
    }
}
