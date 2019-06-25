using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildShowAndHide : Build
{
    public GameObject[] obj_HideObj;//需要隐藏的物体
    public GameObject[] obj_ShowObj;//需要显示的物体

    public override void Init()
    {
        for (int i = 0; i < obj_HideObj.Length; i++)
        {
            obj_HideObj[i].SetActive(false);
        }
        for (int j = 0; j < obj_ShowObj.Length; ++j)
        {
            obj_ShowObj[j].SetActive(true);
            HighlightingSystem.Highlighter a = obj_ShowObj[j].GetComponent<HighlightingSystem.Highlighter>();
            if (a)
            {
                a.enabled = true;
                a.FlashingOn(Color.yellow, Color.yellow);
            }
        }
        Invoke("End", 1);
    }
    public override void End()
    {
        for (int j = 0; j < obj_ShowObj.Length; ++j)
        {
            HighlightingSystem.Highlighter a = obj_ShowObj[j].GetComponent<HighlightingSystem.Highlighter>();
            if (a)
            {
                a.FlashingOff();
                a.enabled = false;
            }
        }
        base.End();
    }
    public override void Reset()
    {
        base.Reset();
        for (int i = 0; i < obj_HideObj.Length; i++)
        {
            obj_HideObj[i].SetActive(true);
        }
        for(int j = 0;j<obj_ShowObj.Length;++j)
        {
            obj_ShowObj[j].SetActive(false);
        }
        CancelInvoke();
    }
}
