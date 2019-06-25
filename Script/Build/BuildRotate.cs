using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildRotate : Build
{
    public Transform obj_RotedObject;//被旋转的物体
    public Vector3 m_TargetRot;//目标旋转角度
    public Vector3 m_RotDic;   //目标旋转方向
    public Vector3 m_StartAngle;//初始旋转角度，用于上一步
    public float m_RotTime;    //旋转时间
    public float m_RotValue;   //旋转角度
    float m_CurRot;//当前旋转角度
    float m_RotSpeed;

    
    void Update () {
        float r = Time.deltaTime * m_RotSpeed;
        m_CurRot += r;
        if(m_CurRot < m_RotValue)
        {
            obj_RotedObject.Rotate(m_RotDic * r);
            return;
        }
        obj_RotedObject.eulerAngles = m_TargetRot;
        base.End();
	}
    public override void Init()
    {
        m_CurRot = 0;
        //m_RotValue = Vector3.Dot( m_RotDic , m_TargetRot);
        m_RotSpeed = m_RotValue / m_RotTime;
    }
    public override void Reset()
    {
        base.Reset();
        obj_RotedObject.localEulerAngles = m_StartAngle;
    }
}
