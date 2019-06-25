using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 木尺动画，木尺的长度是100mm，测量开始点在0，木尺末端在 1f
/// </summary>
public class MuChi : MonoBehaviour {
    public float m_Length;//测量长度 
    public float m_Speed;
    public bool m_End;
    LineRenderer m_Line;
    float m_RelativeLength;//相对长度
    float m_CurLength;//当前测量长度
    //Vector3 m_
	// Use this for initialization
	void OnEnable () {
        m_Line = GetComponent<LineRenderer>();
        m_Line.enabled = true;
        m_RelativeLength = m_Length / 100.0f;//木尺长度为100mm
        m_CurLength = 0;
        m_Line.SetPosition(1, new Vector3(0.02f, 0f, 0));
	}
	
	// Update is called once per frame
	void Update () {
        if (m_End)
            return;
        float a = m_Speed * Time.deltaTime;
        if (m_CurLength + a > m_RelativeLength)
        {
            m_CurLength = m_RelativeLength;
            m_End = true;
        }
        else
        {
            m_CurLength += a;
        }
        /// 设置测量终点位置
        m_Line.SetPosition(1, new Vector3(0.02f, m_CurLength,0));
	}
    public void Reset()
    {
        m_RelativeLength = m_Length / 100.0f;//木尺长度为100mm
        m_CurLength = 0;
        m_Line.SetPosition(1, new Vector3(0.02f, 0f, 0));
        m_End = false;
    }
}
