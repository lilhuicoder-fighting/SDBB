using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetKongPos : MonoBehaviour {
    public int m_number;//本圈中，孔的个数
    public Transform[] obj_Kong;
    public bool m_HasFirst0;//是否包含角度为0的那个点
	// Use this for initialization
	void Start () {
        float angle, startAngle;
        if(m_HasFirst0)
        {
            angle = 180.0f / (m_number - 1);
            startAngle = 0;
        }
        else
        {
            angle = 180.0f / (m_number+1);
            startAngle = angle;
        }
        for (int i = 0; i < obj_Kong.Length; ++i)
            obj_Kong[i].localEulerAngles = new Vector3(0, 0, -startAngle-angle * i);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
