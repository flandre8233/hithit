using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameStatus : Status
{
    public override void Start()
    {
        if (GameModeControl.instance.GetGameMode() == GameModeEnum.TimeAttack)
        {
            manager.instance.timeLeft = TimeLeft.Create(45, manager.instance.OnTimeEnd);
        }

        CanvasSwitcher.instance.ToGameCanvas();

        BackgroundBGM.instance.Play();
    }

    public override void Update()
    {

    }

    public override void ExitStatus()
    {
        BackgroundBGM.instance.Stop();
    }
}