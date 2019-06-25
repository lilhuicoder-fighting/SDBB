using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildZuan : BuildSetModel
{
    public string m_hintText;
    public float m_ZuanLength; //钻深
    public Vector3 m_SmokePos;  //钻孔特效位置
    public Vector3 m_SmokeRot;   //钻孔特效转角
    public Transform obj_SmokeParticle; //钻孔时的特效

    DianZuan obj_FengZuan;
    
    // Use this for initialization
    public override void Init()
    {
        base.Init();
        //初始化手扶风钻信息
        obj_FengZuan = obj_SetModel.GetComponent<DianZuan>();
        obj_FengZuan.enabled = true;
        obj_FengZuan.m_Rotate = true;
        obj_FengZuan.m_TargetAngle = m_TargetAngle;
        obj_FengZuan.m_TargetPos = m_TargetPos;
        obj_FengZuan.m_ZuanDepth = m_ZuanLength;
        obj_FengZuan.Reset();
        //初始化钻孔特效位置
        obj_SmokeParticle.localPosition = m_SmokePos;
        obj_SmokeParticle.localEulerAngles = m_SmokeRot;
        obj_SmokeParticle.gameObject.SetActive(true);
        obj_SmokeParticle.GetComponent<ParticleSystem>().Play();
    }
	
	// Update is called once per frame
	void Update () {
        if (obj_FengZuan.m_Rotate)
            return;
        ShowText(m_hintText,m_SmokePos);
        Invoke("ToEnd", 1);
    }

    public override void ToEnd()
    {
        obj_SmokeParticle.GetComponent<ParticleSystem>().Stop();
        base.ToEnd();
    }
    public override void Reset()
    {
        base.Reset();
        obj_SmokeParticle.gameObject.SetActive(false);
        obj_FengZuan.enabled = false;
        obj_FengZuan.m_Rotate = false;
        CancelInvoke();
    }
}
