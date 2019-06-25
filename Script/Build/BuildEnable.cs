using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildEnable : Build
{
    public GameObject obj_GameObj;
    public int m_LastTime;//持续时间

    public override void Init()
    {
        obj_GameObj.GetComponent<BaibanBi>().enabled = true;
        Invoke("End", 3);
    }
    public override void End()
    {
        obj_GameObj.GetComponent<BaibanBi>().enabled = false;
        base.End();
    }
    public override void Reset()
    {
        obj_GameObj.GetComponent<BaibanBi>().enabled = false;
    }
}
