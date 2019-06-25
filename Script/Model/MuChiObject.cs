using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuChiObject : Model {
    //MuChi m_ChiZi;
	// Use this for initialization
	void Start () {
        //m_ChiZi = GetComponent<MuChi>();
        //m_ChiZi.enabled = false;
	}
	
	// Update is called once per frame
	//void Update () {
 //       if (m_ChiZi.m_End)
 //           ActionStop();
	//}
    //public override void ActionStart()
    //{
    //    m_ChiZi.enabled = true;
    //}
    public override void ActionStop()
    {
        base.ActionStop();
        Destroy(gameObject);
    }
}
