using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildEnableRender : Build {
    public GameObject obj_RenderObj;

    public override void Init()
    {
        obj_RenderObj.GetComponent<MeshRenderer>().enabled = true;
        Invoke("End", 1);
    }

    public override void Reset()
    {
        base.Reset();
        obj_RenderObj.GetComponent<MeshRenderer>().enabled = false;
    }
}
