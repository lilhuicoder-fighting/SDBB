using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 不需要创建模型，只要名称与当前步骤相符就下一步
/// </summary>
public class NotCreate : MonoBehaviour {
    public string m_ToolName;
    public ShowHint obj_ShowHint;//当点击错误时，出现提示信息
    public string m_Hint;
    public int m_CreateTime;
    public int m_CurCreateTime;
    // Use this for initialization
    void Start () {
        gameObject.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(Create);
        m_CurCreateTime = 0;
    }
	public void Create()
    {
        string name = BuildIng.Instance.GetCurModelName();
        if((!name.Contains(m_ToolName))|| m_CurCreateTime >= m_CreateTime)
        {
            if (!obj_ShowHint.gameObject.activeInHierarchy)
                obj_ShowHint.ShowHideIn2S(m_Hint);
            return;
        }
        //if (m_CurCreateTime >= m_CreateTime)
        //    return;
        ++m_CurCreateTime;
        BuildIng.Instance.obj_curBuildProcess.End();
    }
    public void Reset()
    {
        m_CurCreateTime = 0;
    }
}
