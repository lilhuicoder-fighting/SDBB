using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMuChi : BuildSetModel
{
    public float m_MeasureLength;//测量长度
    MuChi obj_MuChi;
    bool m_Showed;
    // Use this for initialization
    public override void Init()
    {
        base.Init();
        obj_MuChi = obj_SetModel.GetComponent<MuChi>();
        obj_MuChi.m_Length = m_MeasureLength;
        obj_MuChi.enabled = true;
        obj_MuChi.Reset();
        m_Showed = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (obj_MuChi.m_End && !m_Showed)
        {
            m_Showed = true;
            ShowText(m_MeasureLength.ToString() + "cm");
            Invoke("ToEnd", 1);
        }
    }
    public override void Reset()
    {
        base.Reset();
        obj_MuChi.enabled = false;
        obj_MuChi.Reset();
        CancelInvoke();
    }
}
