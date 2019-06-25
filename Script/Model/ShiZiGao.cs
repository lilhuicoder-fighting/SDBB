using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiZiGao : Model {
    public float m_Speed;//旋转速度
    public float m_Angle;//旋转角度
    bool m_ISHam;  //开始捶打
    int m_Time;   //捶打次数
    float m_CurAngle;
   

    public override void Init()
    {
        base.Init();
        m_ISHam = false;
        m_Time = 5;
        m_CurAngle = 3;
    }
    public override void ActionStart()
    {
        m_ISHam = true;
    }
    public override void ActionStop()
    {
        Destroy(gameObject);
        base.ActionStop();
    }
    private void Update()
    {
        if (!m_ISHam)
            return;
        m_CurAngle += m_Speed * Time.deltaTime * (1 + m_CurAngle / 20);
        if (m_Speed < 0 && m_CurAngle < 0)
        {
            m_Speed = -m_Speed * 2;
        }
        else if (m_Speed > 0 && m_CurAngle > m_Angle)
        {
            m_Speed = -m_Speed / 2;
            --m_Time;
            if (m_Time < 1)
            {
                m_ISHam = false;
                enabled = false;
                ActionStop();
            }
        }
        else
            transform.Rotate(0, 0, m_Speed * Time.deltaTime);
    }
    public override void Reset()
    {
        Destroy(gameObject);
    }
}
