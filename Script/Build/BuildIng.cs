using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 管理墙体整个建造情况信息
/// </summary>
public class BuildIng : MonoBehaviour {
    public static BuildIng Instance;
    public Build obj_curBuildProcess;
    public StepManager obj_StepDrop;
    //public UnityEngine.UI.Button obj_NextBut;
    int m_CurStep;
    int m_TotleSetp;
    private void Start()
    {
        Instance = this;
        m_CurStep = 0;
        m_TotleSetp = obj_StepDrop.GetTotleStep();
    }
    public string GetCurModelName()
    {
        if(obj_curBuildProcess.GetComponent<BuildNoCreate>())
            return obj_curBuildProcess.GetComponent<BuildNoCreate>().m_ModelName;
        return "null";
    }
    public GameObject GetCurRightModel()
    {
        if (obj_curBuildProcess.GetComponent<BuildHintPos>())
            return obj_curBuildProcess.GetComponent<BuildHintPos>().obj_RightPos;
        return null;
    }
    //上一步
    public void LastStep()
    {
        obj_curBuildProcess.LastStep();
        if (m_CurStep <= 0)
            return;

        --m_CurStep;
        obj_StepDrop.SetStep(m_CurStep);
        //obj_StepDrop.value = m_CurStep;
    }
    //下一步
    /// <summary>
    /// 仅是修改当前步骤UI
    /// </summary>
    public void NextStep()
    {
        ++m_CurStep;
        if (m_CurStep < m_TotleSetp)
            obj_StepDrop.SetStep(m_CurStep);
        Debug.Log("current build name = " + obj_curBuildProcess.name);
        //obj_StepDrop.value = m_CurStep;
    }
    //关闭细节提示窗口
    public void CloseInfor()
    {
        obj_curBuildProcess.End();
    }
}
