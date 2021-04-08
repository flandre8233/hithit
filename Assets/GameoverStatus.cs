using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameoverStatus : Status
{
    public override void Start()
    {
        CanvasSwitcher.instance.ToGameOver();
    }

    public override void Update()
    {

    }

    public override void ExitStatus()
    {

    }
}