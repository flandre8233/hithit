using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSwitcher : SingletonMonoBehavior<CanvasSwitcher>
{
    [SerializeField] GameObject[] Canvas;
    void CloseAllCanvas()
    {
        foreach (GameObject SingleCanvasObject in Canvas)
        {
            SingleCanvasObject.SetActive(false);
        }
    }
    void OpenOnlyOneCanvas(int Index)
    {
        CloseAllCanvas();
        Canvas[Index].SetActive(true);
    }

    public void ToReadyCanvas()
    {
        OpenOnlyOneCanvas(0);
    }
    public void ToGameCanvas()
    {
        OpenOnlyOneCanvas(1);
    }
    public void ToGameOver()
    {
        OpenOnlyOneCanvas(2);
    }
}
