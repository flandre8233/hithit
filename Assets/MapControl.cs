using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class MapControl : SingletonMonoBehavior<MapControl>
{
    public GameObject DangerBeadPrefab;
    public GameObject[] beadObjectArray;
    public int rowNumber;
    public int beadWidth;
    public List<int> allRowData;
    public List<GameObject> allBeadArray;

    private void Start()
    {
        SerializeGameMap();
    }

    void SerializeGameMap()
    {
        for (int i = 0; i < 10; i++)
        {
            serializeOneRow();
        }
    }

    void serializeOneRow()
    {
        int perBeadX = 5 / rowNumber;
        int perBeadY = 1;
        int thisRowSpawnNumber = Random.Range(0, rowNumber);
        GameObject SpawnPrefab = null;
        if (Random.Range(0, 100) <= 15 && !IsBombBeadOver() )
        {
            allRowData.Add(-5);
            SpawnPrefab = DangerBeadPrefab;
        }
        else
        {
            allRowData.Add(thisRowSpawnNumber);
            SpawnPrefab = beadObjectArray[thisRowSpawnNumber];
        }
        Vector3 thisBeadVector3 = new Vector3(0 + perBeadX * thisRowSpawnNumber, perBeadY * allRowData.Count - 1, 0);
        GameObject go = Instantiate(SpawnPrefab, thisBeadVector3, Quaternion.identity);
        allBeadArray.Add(go);
    }

    bool IsBombBeadOver(){
        return allRowData.Where(x=>x <= -5).Count() >= 5;
    }

    void allRowFallDown()
    {
        foreach (var item in GameObject.FindGameObjectsWithTag("bead"))
        {
            item.transform.position = new Vector3(item.transform.position.x, item.transform.position.y - 1, 0);
        }
    }

    public void FallOnce()
    {
        allRowData.RemoveAt(0);
        Destroy(allBeadArray[0]);
        allBeadArray.RemoveAt(0);
        allRowFallDown();
        serializeOneRow();
    }

    public bool IsHitCorrectRow(Vector2Int PlayerInputPos)
    {
        return (GetNowTarget() == PlayerInputPos);
    }

    public Vector2Int GetNowTarget()
    {
        for (int i = 0; i < allRowData.Count; i++)
        {
            if (allRowData[i] >= 0)
            {
                return new Vector2Int(allRowData[i], i);
            }
        }
        return new Vector2Int(0, 0);
    }

    public GameObject GetBead(int Height)
    {
        return allBeadArray[Height];
    }

}
