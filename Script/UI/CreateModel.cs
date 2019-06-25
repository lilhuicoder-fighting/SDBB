using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateModel : NotCreate
{
    public GameObject obj_Model;//点击按钮后，创建模型
    public Transform obj_Parent;//模型的父物体
    //public ShowHint obj_ShowHint;//当点击错误时，出现提示信息
    //public string m_Hint;
    protected GameObject m_model;//创建后的模型
    public BuildIng obj_BuildManager;
    public MoveFollowMouse obj_Player;
    //public int m_CreateTime;
    //public int m_CurCreateTime;
    //public bool 
    // Use this for initialization
    public virtual void Start() {
        gameObject.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(Create);
        m_CurCreateTime = 0;
    }

    // Update is called once per frame
    void Update() {

    }
    public virtual void Create() 
    {
        string na = obj_BuildManager.GetCurModelName();
        //if (obj_Model.name != na)
        if((!na.Contains(obj_Model.name))|| m_CurCreateTime >= m_CreateTime)
        {
            if(!obj_ShowHint.gameObject.activeInHierarchy)
                obj_ShowHint.ShowHideIn2S(m_Hint);
            return;
        }
        //if (m_CurCreateTime >= m_CreateTime)
        //    return;
        CreateModelOrTool();
        InitModel();
    }
    public void CreateModelOrTool()
    {
        ++m_CurCreateTime;
        m_model = Instantiate(obj_Model);
        BuildHintPos a = obj_BuildManager.obj_curBuildProcess.GetComponent<BuildHintPos>();
        if(a)
            a.obj_CloneObject = m_model;
        
    }
    public void InitModel()
    {
        Model m = m_model.GetComponent<Model>();
        m.obj_StopListener = obj_BuildManager.obj_curBuildProcess.gameObject;
        m.obj_RightModel = obj_BuildManager.GetCurRightModel();
        HighlightingSystem.Highlighter hler = m.obj_RightModel.GetComponent<HighlightingSystem.Highlighter>();
        if (hler)
            hler.FlashingOn(Color.green, Color.green);
        m.Init();
        m_model.transform.parent = obj_Parent;
        m_model.transform.localPosition = Vector3.zero;
        obj_Player.m_MoveObject = m_model.transform;
        obj_Player.Init();
    }
    public virtual void Reset()
    {
        m_CurCreateTime = 0;
    }
}
