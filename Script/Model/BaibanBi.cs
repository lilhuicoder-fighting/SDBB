using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaibanBi : MonoBehaviour {
    public Vector3 m_Axis;//旋转轴
    public Vector3 m_BeginPos;//画笔开始点
    public float m_Speed;//旋转速度
    public Quaternion m_Point;//旋转点
    public GameObject obj_LineObject;
    public bool m_End;
    protected float m_CurRotateValue;//当前旋转的角度
    protected float m_CurLineValue;//记录当前线条距离上一个点的长度，0.5个弧度增加一点
    protected Vector3 m_StartPos;
    protected int m_CurLinePoint;
    protected LineRenderer obj_Line;
    private GameObject obj_Point;
    private Quaternion m_CurPoint;
    // Use this for initialization
    public virtual void Start () {
        obj_Point = Instantiate(obj_LineObject);
        obj_Line = obj_Point.GetComponent<LineRenderer>();
        m_StartPos = transform.position;
        m_CurLinePoint = 0;
        m_CurPoint = m_Point;
        AddPoint(m_BeginPos);
        ++m_CurLinePoint;
        m_CurLineValue = 0;
        m_CurRotateValue = 0;
    }

    // Update is called once per frame
   public void Update () {
        Rotate();
    }
    protected virtual void Rotate()
    {
        if (m_End)
            return;
        float a = m_Speed * Time.deltaTime;//本次旋转角度
        m_CurRotateValue += a;
        if (m_CurRotateValue > 12)
        {
            m_End = true;
        }
        float sinA = Mathf.Sin(0.5f * a);
        float cosA = Mathf.Cos(0.5f * a);
        Quaternion q = new Quaternion(0, 0, sinA, cosA);
        Quaternion q1 = new Quaternion(0, 0, -sinA, cosA);
        m_Point = q * m_Point * q1;
        m_CurPoint = m_Point;
        m_CurPoint.x += Random.Range(-0.005f, 0.005f);
        Vector3 piYiPos = new Vector3(m_CurPoint.x, m_CurPoint.y, m_CurPoint.z);
        transform.position = m_StartPos + piYiPos;
        //中心位置不变，旋转角度
        //transform.rotation = Quaternion.AngleAxis(a, m_Axis) * transform.rotation;
        m_CurLineValue += a;
        if(m_CurLineValue > 0.5f)
        {
            AddPoint(m_BeginPos + piYiPos);
            m_CurLineValue -= 0.5f;
        }
    }
    /// <summary>
    /// 将当前位置添加到LineRender列表中
    /// </summary>
    protected void AddPoint(Vector3 pos)
    {
        if (m_CurLinePoint > obj_Line.positionCount -1)
            return;
        for(int i = m_CurLinePoint; i< obj_Line.positionCount ; ++i)
        {
            obj_Line.SetPosition(i, pos);
        }
        ++m_CurLinePoint;
    }
    private void OnDisable()
    {
        Destroy(obj_Point);
    }
    private void OnDestroy()
    {
        Destroy(obj_Point);
    }
}
