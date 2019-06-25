using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildHintPos : BuildNoCreate
{
    public GameObject obj_RightPos;//正确位置标记模型；
    //public CreateModel obj_RelatedBut;//相关的按钮
    public GameObject obj_CloneObject;//创建出来的物体
    //public string m_ModelName;
    public override void Reset()
    {
        if (obj_RelatedBut)
            obj_RelatedBut.Reset();
        if (obj_CloneObject)
        {
            if (obj_CloneObject.GetComponent<Model>())
                obj_CloneObject.GetComponent<Model>().Reset();
            Destroy(obj_CloneObject);
        }
        if (obj_RightPos.activeSelf)
            obj_RightPos.SetActive(false);
        base.Reset();
    }
}
