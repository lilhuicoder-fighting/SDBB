using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HighlightingSystem;
/// <summary>
/// 显示其它模型
/// </summary>
public class BuildShowM : Build {
    public Highlighter obj_HighLightObj;
    public GameObject[] obj_ActiveObj;

    public override void Init()
    {
        for(int i=0;i<obj_ActiveObj.Length;i++)
        {
            obj_ActiveObj[i].SetActive(true);
        }
        if (obj_HighLightObj)
        {
            obj_HighLightObj.enabled = true;
            obj_HighLightObj.FlashingOn(Color.yellow, Color.yellow);
            
        }
        Invoke("End", 2);
    }
    public override void End()
    {
        if(obj_HighLightObj)
        {
            obj_HighLightObj.FlashingOff();
            obj_HighLightObj.enabled = false;
        }
        base.End();
    }

    public override void Reset()
    {
        base.Reset();
        for (int i = 0; i < obj_ActiveObj.Length; i++)
        {
            obj_ActiveObj[i].SetActive(false);
        }
        if (obj_HighLightObj)
        {
            obj_HighLightObj.FlashingOff();
            obj_HighLightObj.enabled = false;
        }
        CancelInvoke();
    }
}
