using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyStatus : Status
{
    float KeyingTime;
    float KeyUpTime;
    float ReadyStartTime;

    public override void Start()
    {
        CanvasSwitcher.instance.ToReadyCanvas();
        ReadyStartTime = Time.time;
    }

    public override void Update()
    {
        if (Time.time - ReadyStartTime >= 0.5f)
        {
            PlayerInputListener();
        }
    }

    void PlayerInputListener()
    {

        if (Input.GetMouseButton(0))
        {
            KeyingTime += Time.deltaTime;
        }
        if (Input.GetMouseButtonUp(0))
        {
            CountResult();
            KeyingTime = 0;
        }
    }

    void CountResult()
    {
        if (KeyingTime <= 1)
        {
            GameModeControl.instance.ToTimeAttackMode();
        }
        else
        {
            GameModeControl.instance.ToInfiniteMode();
        }
        StatusControll.ToNewStatus(new GameStatus());
    }

    public override void ExitStatus()
    {
    }
}