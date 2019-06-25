using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildHideZha : Build
{
    public GameObject obj_HideObj;//需要隐藏的物体
    public DiaoShiTao obj_ShiTou;
    public SuiShi obj_BaoZhaShi;
    // Use this for initialization
    public override void Init()
    {
        obj_HideObj.SetActive(false);
        obj_ShiTou.gameObject.SetActive(false);
        obj_BaoZhaShi.GetCreatedShi().SetActive(false);
        Invoke("End", 1);
    }

    public override void Reset()
    {
        base.Reset();
        obj_HideObj.SetActive(true);
        obj_ShiTou.gameObject.SetActive(true);
        obj_BaoZhaShi.GetCreatedShi().SetActive(true);
    }
}
