using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildScale : Build {
    public Transform obj_MovedObject; //被缩放的物体
    public Vector3 m_TargetScale;     //目标大小
    public float m_MoveTime;          //移动时间
    public Vector3 m_StartScale;      //初始大小
    float m_CurScale;
    float m_ScaleSpeed;
    float m_Dis; //总共缩放的大小
    Vector3 m_ScaleDic;
    // Use this for initialization
    void Start () {
		
	}
    public override void Init()
    {
        m_ScaleDic = (m_TargetScale - m_StartScale).normalized;
        m_Dis = Vector3.Distance(m_StartScale, m_TargetScale);
        m_CurScale = 0;
        m_ScaleSpeed = m_Dis / m_MoveTime;
    }

    public override void Reset()
    {
        base.Reset();
        obj_MovedObject.localScale = m_StartScale;
    }
    // Update is called once per frame
    void Update () {
        m_CurScale += Time.deltaTime * m_ScaleSpeed;
        if (m_CurScale < m_Dis)
            obj_MovedObject.localScale = m_CurScale * m_ScaleDic;
        else
        {
            obj_MovedObject.localScale = m_TargetScale;
            base.End();
        }
    }
}
