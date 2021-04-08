using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameModeEnum
{
    TimeAttack,
    Infinite
}
public class GameModeControl : SingletonMonoBehavior<GameModeControl>
{
    GameModeEnum GameMode;

    private void Start()
    {
        GameMode = GameModeEnum.Infinite;
    }

    public void SetGameMode(GameModeEnum NewEnum)
    {
        GameMode = NewEnum;
    }

    public GameModeEnum GetGameMode()
    {
        return GameMode;
    }

    public void ToTimeAttackMode()
    {
        GameMode = GameModeEnum.TimeAttack;
    }
    public void ToInfiniteMode()
    {
        print("ToInfiniteMode");
        GameMode = GameModeEnum.Infinite;
    }


}
