using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class pointHit : SingletonMonoBehavior<pointHit>
{
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            manager.instance.button(GridTheMousePoint());
        }

    }

    Vector2Int GridTheMousePoint()
    {
        Vector3 MouseWorldPoint = Camera.main.ScreenToWorldPoint(GetMouseScreenPoint());
        MouseWorldPoint = new Vector3(Mathf.Clamp(MouseWorldPoint.x ,0, Camera.main.pixelWidth) , Mathf.Clamp(MouseWorldPoint.y, 0 , Camera.main.pixelHeight) , MouseWorldPoint.z  );

        Vector2 TargetMap = MapControl.instance.GetNowTarget();
        if (Vector2.Distance(TargetMap, new Vector2(MouseWorldPoint.x, MouseWorldPoint.y)) <= .75f)
        {
            return MapControl.instance.GetNowTarget();
        }
        return new Vector2Int(Mathf.RoundToInt(MouseWorldPoint.x), Mathf.RoundToInt(MouseWorldPoint.y));
    }

    Vector2 GetMouseScreenPoint()
    {
        return Input.mousePosition;
    }
}
