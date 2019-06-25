using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour {
    public float m_disToFloor;
    public float m_disToForwardWall; //前面墙壁的距离，确保移动物体时，不会穿到墙内
    public float m_disToUpWall;      //顶部天花板的距离，确保移动物体时，不会穿到天花板
    public GameObject obj_RightModel;//正确位置标记模型；
    //public Vector3 m_FinalPos;       //最终位置
    public GameObject obj_StopListener;//行为终止后，被通知的物体

	// Use this for initialization
    public virtual void Init()
    {
        if(obj_RightModel)
        {
            obj_RightModel.SetActive(true);
        }
    }
	public virtual void ActionStart()
    {
        ActionStop();
    }
    public virtual void ActionStop()
    {
        obj_StopListener.GetComponent<Build>().End();
    }
    //模型到达正确位置
    public void ToRightPos()
    {
        //transform.localPosition = m_FinalPos;//需更改风管之前安装的工序中手拿物体所到的位置的实现方法
        transform.position = obj_RightModel.transform.position;
        HighlightingSystem.Highlighter hler = obj_RightModel.GetComponent<HighlightingSystem.Highlighter>();
        //obj_RightModel.GetComponent<BoxCollider>().enabled = false;
        //obj_RightModel.tag = "Untagged";
        if (hler)
            hler.FlashingOff();
        obj_RightModel.SetActive(false);
    }
    public virtual void Reset()
    {
        //
    }
}
