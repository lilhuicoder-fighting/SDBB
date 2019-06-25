using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildHideM : Build {
    public GameObject[] obj_HideObj;//需要隐藏的物体

    public override void Init()
    {
        for (int i = 0; i < obj_HideObj.Length; i++)
        {
            obj_HideObj[i].SetActive(false);
        }
        Invoke("End", 1);
    }
    public override void End()
    {
        base.End();
    }
    public override void Reset()
    {
        base.Reset();
        for (int i = 0; i < obj_HideObj.Length; i++)
        {
            obj_HideObj[i].SetActive(true);
        }
    }
}
