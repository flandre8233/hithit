using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockerControl : SingletonMonoBehavior<BlockerControl>
{
    [SerializeField] GameObject SingleBlockerPrefab;
    int BlockRow;
    List<GameObject> Blockers = new List<GameObject>();
    int ComboCounter = 0;

    public void DebuffJudge()
    {
        if (GameModeControl.instance.GetGameMode() == GameModeEnum.Infinite)
        {
            return;
        }

        if (Blockers.Count > 0)
        {
            ComboCounter++;
        }
        else
        {
            if (Random.Range(0, 100) <= 5)
            {
                SpawnOneRowBlocker();
                BlockRow = Random.Range(0, 3);
            }
        }

        if (ComboCounter >= 10)
        {
            RemoveBlockers();
            ComboCounter = 0;
        }

    }

    void SpawnOneRowBlocker()
    {
        Invoke("Spawn1Blocker", 0f);
        Invoke("Spawn2Blocker", 0.2f);
        Invoke("Spawn3Blocker", 0.4f);
        Invoke("Spawn4Blocker", 0.6f);
    }

    void Spawn1Blocker()
    {
        Blockers.Add(SpawnBlocker(new Vector2Int(0, BlockRow)));
    }
    void Spawn2Blocker()
    {
        Blockers.Add(SpawnBlocker(new Vector2Int(1, BlockRow)));
    }
    void Spawn3Blocker()
    {
        Blockers.Add(SpawnBlocker(new Vector2Int(2, BlockRow)));
    }
    void Spawn4Blocker()
    {
        Blockers.Add(SpawnBlocker(new Vector2Int(3, BlockRow)));
    }

    public void RemoveBlockers()
    {
        for (int i = 0; i < Blockers.Count; i++)
        {
            Blockers[i].GetComponent<Blocker>().ExitDelay(0.2f * i);
        }
        Blockers = new List<GameObject>();
    }

    GameObject SpawnBlocker(Vector2Int SpawnPoint)
    {
        GameObject SpawnObj = Instantiate(SingleBlockerPrefab, new Vector3(SpawnPoint.x, SpawnPoint.y), Quaternion.identity);
        return SpawnObj;
    }
}
