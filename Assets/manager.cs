using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour {
    public static manager Static;

    public GameObject beadObject;
    public int rowNumber;
    public int beadWidth;
    public List<int> allRowData;
    public List<GameObject> allBeadArray;

    public int score = 0;
    public int combo = 0;
    public float gameStartTimeLeft = 30;

    public bool inGameover = false;
    public bool start = false;

    private void Awake()
    {
        if (Static != null)
        {
            Destroy(this);
        }
        else
        {
            Static = this;
        }
    }

    // Use this for initialization
    void Start ()
    {
        serializeOneRow();
        serializeOneRow();
        serializeOneRow();
        serializeOneRow();
        serializeOneRow();
        serializeOneRow();
        serializeOneRow();
        serializeOneRow();
    }

    private void Update()
    {
        playerContorl();
        gameStartTimer();
        resetKetboard();
    }

    void resetKetboard()
    {
        if (!inGameover)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            canvaScript.Static.resetButton();
        }

    }

    void gameStartTimer()
    {
        if (!start || inGameover)
        {
            return;
        }

        if (gameStartTimeLeft >0)
        {
            gameStartTimeLeft -= Time.deltaTime;
        }
        else
        {
            gameStartTimeLeft = 0;
            failhit();
        }
    }

    void allRowFixPos()
    {
        foreach (var item in GameObject.FindGameObjectsWithTag("bead") )
        {
            item.transform.position = new Vector3(item.transform.position.x, item.transform.position.y-1,0);
        }
    }

    void hitRightBead()
    {
        combo++;
        //gameStartTimeLeft = 2;
        score += (int)(combo * (1*(30 - gameStartTimeLeft)));
        allRowData.RemoveAt(0);
        Destroy(allBeadArray[0]);
        allBeadArray.RemoveAt(0);
        allRowFixPos();
        serializeOneRow();
    }

    void playerContorl()
    {
        if (inGameover)
        {
            return ;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            start = true;
            Debug.Log("hit");
            if (allRowData[0] == 0)
            {
                hitRightBead();
            }
            else
            {
                failhit();
            }
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            start = true;
            if (allRowData[0] == 1)
            {
                hitRightBead();
            }
            else
            {
                failhit();
            }
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            start = true;
            if (allRowData[0] == 2)
            {
                hitRightBead();
            }
            else
            {
                failhit();
            }
        }
        canvaScript.Static.updateText(score, combo, gameStartTimeLeft);
    }

    void failhit()
    {
        //gameStart = 0;
        gameStartTimeLeft = 0;
        canvaScript.Static.goGameover();
    }



    void serializeOneRow()
    {
        int perBeadX = 5 / rowNumber;
        int perBeadY = 1;
        int thisRowSpawnNumber = Random.Range(0,rowNumber);
        allRowData.Add(thisRowSpawnNumber);
        Vector3 thisBeadVector3 = new Vector3(perBeadX * thisRowSpawnNumber,perBeadY*allRowData.Count-1,0);

        allBeadArray.Add(Instantiate(beadObject, thisBeadVector3, Quaternion.identity ) );
        /*
        for (int i = 0; i < rowNumber; i++)
        {
            Instantiate(beadObject, new Vector3(perBeadX*i,perBeadY,0) ,Quaternion.identity);
        }
        */
    }

    

}
