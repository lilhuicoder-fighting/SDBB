using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenQiObject : Model {
    public GameObject obj_PenQiTong;
    GameObject obj_ColonTong;
    PenQi m_qi;
    bool m_Start;
	// Use this for initialization
	void Start () {
        m_Start = false;

    }
	
	// Update is called once per frame
	void Update () {
        if (!m_Start)
            return;
        if (m_qi.m_End)
            ActionStop();
	}
    public override void ActionStart()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        obj_ColonTong = Instantiate(obj_PenQiTong);
        m_qi = obj_ColonTong.GetComponent<PenQi>();
        m_Start = true;
    }
    public override void ActionStop()
    {
        base.ActionStop();
        Destroy(obj_ColonTong);
        Destroy(gameObject);
    }
}
