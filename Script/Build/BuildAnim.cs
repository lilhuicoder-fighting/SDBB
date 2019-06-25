using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildAnim : Build {
    public GameObject obj_AnimObject;
    public GameObject obj_Spark;
    public string m_AnimName;
    Animation m_Anim;
    Vector3 m_ObjectStartPos;
    bool m_EndAnim;
    public override void Init()
    {
        m_Anim = obj_AnimObject.GetComponent<Animation>();
        m_ObjectStartPos = obj_AnimObject.transform.position;
        m_Anim.Play(m_AnimName);
        if(obj_Spark)
            obj_Spark.SetActive(true);
        m_EndAnim = false;
    }
    
	
	// Update is called once per frame
	void Update () {
        if (!m_EndAnim && !m_Anim.IsPlaying(m_AnimName))
        {
            m_EndAnim = true;
            ToEnd();
        }
    }
    void ToEnd()
    {
        if (obj_Spark)
            obj_Spark.GetComponent<ParticleSystem>().Stop();
        Invoke("End", 2);
    }
    public override void End()
    {
        Debug.Log("End :" + gameObject.name);
        base.End();

    }
    public override void Reset()
    {
        if (obj_Spark)
            obj_Spark.SetActive(false);
        m_Anim.Stop();
        obj_AnimObject.transform.position = m_ObjectStartPos;
    }
}
