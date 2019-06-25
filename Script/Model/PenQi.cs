using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenQi : BaibanBi
{
    public Transform obj_linePos;
    protected override void Rotate()
    {
        float a = m_Speed * Time.deltaTime;//本次旋转角度
        m_CurRotateValue += a;
        if (m_CurRotateValue > 180)
        {
            gameObject.SetActive(false);
            m_End = true;
        }
        transform.rotation = Quaternion.AngleAxis(a, m_Axis) * transform.rotation;
        m_CurLineValue += a;
        if(m_CurLineValue >1.2f)
        {
            AddPoint(obj_linePos.position);
            m_CurLineValue -= 1.2f;
        }
    }
}
