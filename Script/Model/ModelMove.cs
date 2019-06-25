using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelMove : Model {

    public float m_UpHeight;
    public Vector3 m_MoveAxis;
    public float m_Speed;
    bool m_isUP;
    float m_CurHeight;
    public override void Init()
    {
        base.Init();
        m_isUP = false;
        m_CurHeight = 0;
    }
    public override void ActionStart()
    {
        m_isUP = true;
    }
    void Update()
    {
        if (!m_isUP)
            return;
        float h = m_Speed * Time.deltaTime;
        m_CurHeight += h;
        if (m_CurHeight > m_UpHeight)
        {
            transform.Translate(m_MoveAxis * (h - m_CurHeight), Space.World);
            transform.Translate(m_MoveAxis * m_UpHeight, Space.World);
            m_isUP = false;
            ActionStop();
            enabled = false;
            return;
        }
        transform.Translate(m_MoveAxis * h, Space.World);
    }
}
