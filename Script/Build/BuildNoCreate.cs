using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildNoCreate : Build
{
    public NotCreate obj_RelatedBut;//相关的按钮
    public string m_ModelName;

    public override void Reset()
    {
        if (obj_RelatedBut)
            obj_RelatedBut.Reset();
        base.Reset();
    }
}
