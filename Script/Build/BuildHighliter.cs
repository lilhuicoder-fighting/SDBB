using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildHighliter : Build {
    public HighlightingSystem.Highlighter obj_HighLightObj;
    public override void Init()
    {
        obj_HighLightObj.gameObject.SetActive(true);
        obj_HighLightObj.enabled = true;
        obj_HighLightObj.FlashingOn(Color.red, Color.red);
        Invoke("End", 0.1f);
    }
    public override void Reset()
    {
        obj_HighLightObj.FlashingOff();
        obj_HighLightObj.enabled = false;
        obj_HighLightObj.gameObject.SetActive(false);
    }

}
