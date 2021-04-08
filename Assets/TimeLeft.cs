using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void TimeEndHandler();
public class TimeLeft : MonoBehaviour
{
    int TimeLeftMax = 0;
    float CurTimeLeft = 0;
    TimeEndHandler timeEnd;

    public static TimeLeft Create(int MaxTime, TimeEndHandler timeEnd)
    {
        GameObject NewObject = new GameObject();
        TimeLeft Component = NewObject.AddComponent<TimeLeft>();
        Component.gameObject.name = Component.GetType().Name;
        Component.timeEnd = timeEnd;
        Component.TimeLeftMax = MaxTime;
        Component.CurTimeLeft = MaxTime;
        return Component;
    }

    private void Update()
    {
        CurTimeLeft = Mathf.Clamp(CurTimeLeft, 0, TimeLeftMax);
        if (IsCounting())
        {
            CurTimeLeft -= Time.deltaTime;
        }
        else
        {
            CountFinish();
        }
    }

    bool IsCounting()
    {
        return CurTimeLeft > 0;
    }

    public void CountFinish()
    {
        if (timeEnd != null)
        {
            timeEnd.Invoke();
        }
        Destroy(gameObject);
    }

    public float GetMaxTime()
    {
        return TimeLeftMax;
    }
    public float GetCurrentTimeLeft()
    {
        return CurTimeLeft;
    }
}
