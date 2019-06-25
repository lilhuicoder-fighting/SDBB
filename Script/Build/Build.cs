using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour {
    public Build obj_NextBuild;//下一步
    public Build obj_LastBuild;//上一步
    //public CreateModel obj_RelatedBut;//相关的按钮
    //public GameObject obj_CloneObject;//创建出来的物体
    //public BuildIng obj_BuildManager;
    public bool m_isStep;//是否能成为独立的一步
    public virtual void Init()
    {
        //
    }
    public virtual void Execute()
    {
        End();
    }
    //本步骤结束，开始下一步
    public virtual void End()
    {
        gameObject.SetActive(false);
        if (!obj_NextBuild)
            return;
        obj_NextBuild.gameObject.SetActive(true);
        obj_NextBuild.Init();
        BuildIng.Instance.obj_curBuildProcess = obj_NextBuild;
        if ("Next" == tag)
        {
            BuildIng.Instance.NextStep();
        }
    }
    //上一步
    public virtual void LastStep()
    {
        gameObject.SetActive(false);
        LastStep(2);
    }
    //上s步
    public virtual void LastStep(int s)
    {
        if (true == m_isStep)
            --s;
        Reset();
        //没有上一步或s=0停留在此步
        if (!obj_LastBuild || 0 == s)
        {
            gameObject.SetActive(true);
            BuildIng.Instance.obj_curBuildProcess = this;
            Init();
            return;
        }

        obj_LastBuild.LastStep(s);
    }
    //重置
    //返回上一步前，先将此步所做的工作重置，创建的物体被销毁，移动的物体被移回......
    public virtual void Reset()
    {
        //if (obj_RelatedBut)
        //    obj_RelatedBut.Reset();
        //if (obj_CloneObject)
        //{
        //    if (obj_CloneObject.GetComponent<Model>())
        //        obj_CloneObject.GetComponent<Model>().Reset();
        //    Destroy(obj_CloneObject);
        //}
        //LineReset lineR = GetComponent<LineReset>();
        //if (lineR)
        //    lineR.Reset();
    }
}
