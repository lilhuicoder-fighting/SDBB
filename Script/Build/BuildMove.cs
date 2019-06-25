using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMove : Build
{
    public Transform obj_MovedObject; //被移动的物体
    public Vector3 m_TargetPos;  //目标位置
    public float m_MoveTime;     //移动时间
    public Vector3 m_StartPos;   //初始位置
    float m_CurMove;
    float m_MoveSpeed;
    float m_Dis;
    bool m_IsAtPos;
    Vector3 m_MoveDic;
    
	
	// Update is called once per frame
	void Update ()
    {
         m_CurMove += Time.deltaTime * m_MoveSpeed;
         if (m_CurMove < m_Dis)
             obj_MovedObject.Translate(m_MoveDic * Time.deltaTime * m_MoveSpeed,Space.World);
         else
         {
             m_IsAtPos = true;
             obj_MovedObject.localPosition = m_TargetPos;
             base.End();
         }
    }
    public override void Init()
    {
        m_MoveDic = (m_TargetPos - obj_MovedObject.localPosition).normalized;
        m_Dis = Vector3.Distance(obj_MovedObject.localPosition, m_TargetPos);
        m_CurMove = 0;
        m_MoveSpeed = m_Dis / m_MoveTime;
    }

    public override void Reset()
    {
        base.Reset();
        obj_MovedObject.localPosition = m_StartPos;
    }
}
