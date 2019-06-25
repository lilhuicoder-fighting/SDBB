using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DianZuan:MonoBehaviour{
    public Vector3 m_TargetPos;
    public Vector3 m_TargetAngle;
    public GameObject obj_ZuanTou;//电钻钻头
    public float m_ZuanDepth;     //电钻钻取的深度
    public float m_ZuanSpeed;     //电钻速度
    public bool m_Rotate;
    float m_CurValue;//当前钻取的深度

    public void OnEnable()
    {
        Reset();
    }
    void Update()
    {
        if (!m_Rotate)
            return;
        float a = m_ZuanSpeed * Time.deltaTime;
        m_CurValue += a;
        if(m_CurValue>m_ZuanDepth)
        {
            m_Rotate = false;
        }
        transform.Translate(-transform.right * a,Space.World);
        obj_ZuanTou.transform.Rotate(1000 * a,0, 0 );
    }
    public void Reset()
    {
        transform.position = m_TargetPos;
        transform.localEulerAngles = m_TargetAngle;
        m_Rotate = true;
        m_CurValue = 0;
    }
}
