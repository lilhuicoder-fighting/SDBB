using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildChangMat : Build {
    public Material m_ChangeMat;
    public float m_Smooth;
    float m_StartSmooth;
    public void Start()
    {
        m_StartSmooth = 2;
        m_ChangeMat.SetFloat("_BumpScale", 2);
    }
    public override void Init()
    {
        m_StartSmooth = m_ChangeMat.GetFloat("_BumpScale");
        m_ChangeMat.SetFloat("_BumpScale", m_Smooth);
        Invoke("End", 1);
    }

    public override void Reset()
    {
        base.Reset();
        CancelInvoke();
        m_ChangeMat.SetFloat("_BumpScale", m_StartSmooth);
    }
}
