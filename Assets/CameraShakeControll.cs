using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeControll : SingletonMonoBehavior<CameraShakeControll>
{
     Vector3 OrlV3;
    Vector3 TargetV3;

    bool IsOpening;

   [SerializeField] float ReNewTargetTime;
    [SerializeField] float ReNewTargetDisantce;
    [SerializeField] float CameraMovementSpeed;

    public void StartShake(float Time)
    {
        Invoke("StartShake",0);
        Invoke("BackToOrlPos", Time);
    }

    public void StartShake()
    {
        if (IsOpening)
        {
            return;
        }

        IsOpening = true;
        globalUpdateManager.instance.registerUpdateDg(Shaking);

        OrlV3 = transform.localPosition;
        InvokeRepeating("ReNewTargetV3", 0, ReNewTargetTime);
        ReNewTargetV3();
    }

    void Shaking()
    {
        CameraMovement();
    }

    void ReNewTargetV3()
    {
        Vector2 Dir = Random.insideUnitCircle * ReNewTargetDisantce;
        TargetV3 = OrlV3 + transform.rotation * Dir;
    }
    void CameraMovement()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, TargetV3,Time.deltaTime * CameraMovementSpeed);
    }

    void BackToOrlPos()
    {
        TargetV3 = OrlV3;
        CancelInvoke("ReNewTargetV3");
        print(Vector3.Distance(transform.localPosition, TargetV3) / CameraMovementSpeed);
        Invoke("EndShake", Vector3.Distance(transform.localPosition , TargetV3 ) / CameraMovementSpeed);
    }

    public void EndShake()
    {
        if (!IsOpening)
        {
            return;
        }
        print("EndShake");
        IsOpening = false;
        globalUpdateManager.instance.UnregisterUpdateDg(Shaking);
        CancelInvoke();

        transform.localPosition = TargetV3;
        OrlV3 = new Vector3();
    }
}
