using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ComboText : CommonUIText
{
    public override void UpdateText()
    {
        text.text = manager.instance.GetCombo().ToString();
    }
}
