using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildResetBut : Build {
    public GameObject obj_ResetBut;
    public bool m_IsCreateBut;

    public override void Init()
    {
        if (m_IsCreateBut)
        {
            obj_ResetBut.GetComponent<CreateModel>().Reset();
        }
        else
            obj_ResetBut.GetComponent<NotCreate>().Reset();
        Invoke("End", 1);
    }

    public override void Reset()
    {
        base.Reset();
        CancelInvoke();
        if (m_IsCreateBut)
        {
            obj_ResetBut.GetComponent<CreateModel>().m_CurCreateTime = 1;
        }
        else
            obj_ResetBut.GetComponent<NotCreate>().m_CurCreateTime = 1;
    }
}
