using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuanZhanYi : Model {
    //public GameObject obj_BaiBanBi;
    //BaibanBi m_HuaBi;
	// Use this for initialization
	//void Start () {
 //       obj_BaiBanBi.GetComponent<HighlightingSystem.Highlighter>().FlashingOn(Color.yellow, Color.yellow);
 //       m_HuaBi = obj_BaiBanBi.GetComponent<BaibanBi>();
	//}
	
	//// Update is called once per frame
	//void Update () {
 //       if (m_HuaBi.m_End)
 //           ActionStop();
	//}
    public override void ActionStart()
    {
        ActionStop();
    }
    ////开始描点
    //private void BeginLine()
    //{
    //    obj_BaiBanBi.SetActive(true);
    //}
    public override void ActionStop()
    {
        base.ActionStop();
        Destroy(gameObject);
    }
}
