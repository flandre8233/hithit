using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : SingletonMonoBehavior<manager>
{
    [SerializeField] GameObject ScoreParticle;
    [SerializeField] GameObject WrongPrefab;
    int score = 0;
    int combo = 0;
    public TimeLeft timeLeft;
    [SerializeField] MapControl MapControl;

    public void button(Vector2Int PlayerInputPos)
    {
        if (MapControl.IsHitCorrectRow(PlayerInputPos))
        {
            OnPLayerHitCorrectRaw(PlayerInputPos);
        }
        else
        {
            OnHitWrongRow(PlayerInputPos);
        }
    }

    void OnPLayerHitCorrectRaw(Vector2Int PlayerInputPos)
    {
        Vector2Int NowTarget = MapControl.instance.GetNowTarget();
        SpawnScoreParticle(NowTarget);
        ComboAdd();
        ScoreCount();

        MapControl.instance.GetBead(NowTarget.y).GetComponent<Crasher>().Crash();

        for (int i = 0; i < PlayerInputPos.y + 1; i++)
        {
            MapControl.FallOnce();
        }

        BlockerControl.instance.DebuffJudge();
    }


    void SpawnScoreParticle(Vector2Int PlayerInputPos)
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(ScoreParticle, new Vector3(PlayerInputPos.x, PlayerInputPos.y, 0), Quaternion.identity);
        }
    }

    void OnHitWrongRow(Vector2Int PlayerInputPos)
    {
        ResourcesSpawner.Spawn("Wrong");
        Instantiate(WrongPrefab, new Vector3(PlayerInputPos.x, PlayerInputPos.y), Quaternion.identity);
        BlockerControl.instance.RemoveBlockers();
        CameraShakeControll.instance.StartShake(0.3f);

        if (MapControl.instance.allRowData[PlayerInputPos.y] <= -5)
        {
            MapControl.instance.GetBead(PlayerInputPos.y).GetComponent<DangerAniControl>().Exp();
        }

        if (timeLeft)
        {
            Destroy(timeLeft.gameObject);
        }
        OnTimeEnd();
    }

    public void OnTimeEnd()
    {
        Destroy(pointHit.instance);
        BlockerControl.instance.CancelInvoke();
        StatusControll.ToNewStatus(new GameoverStatus());
    }

    void ComboAdd()
    {
        combo++;
    }
    void ScoreCount()
    {
        if (GameModeControl.instance.GetGameMode() == GameModeEnum.TimeAttack)
        {
            score += (int)((combo+1) * (1 * (timeLeft.GetMaxTime() - timeLeft.GetCurrentTimeLeft())));
        }
    }

    public int GetScore()
    {
        return score;
    }
    public int GetCombo()
    {
        return combo;
    }
    public float GetTimeLeft()
    {
        if (timeLeft == null)
        {
            return 99.99f;
        }
        return timeLeft.GetCurrentTimeLeft();
    }

}
