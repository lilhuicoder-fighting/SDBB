using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFollowMouse : MonoBehaviour {
    public Camera obj_Cam;
    public Transform m_MoveObject;
    float m_disToFloor;
    float m_disToForward;
    float m_disToUpFloor;
    // Use this for initialization
    
	public void Init()
    {
        m_disToFloor = m_MoveObject.GetComponent<Model>().m_disToFloor;
        m_disToForward = m_MoveObject.GetComponent<Model>().m_disToForwardWall;
        m_disToUpFloor = m_MoveObject.GetComponent<Model>().m_disToUpWall;
    }
	// Update is called once per frame
	void Update () {
        if (!m_MoveObject)
            return;
        
        Ray ray = obj_Cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool bHit = Physics.Raycast(ray, out hit);
        if (bHit)
        {
            if ("Floor" == hit.transform.tag)
            {
                m_MoveObject.transform.position = hit.point + new Vector3(0, m_disToFloor, 0);
            }
            else if ("Qiang" == hit.transform.tag)
            {
                m_MoveObject.transform.position = hit.point + new Vector3(0, 0, m_disToForward);
            }
            else if ("Ding" == hit.transform.tag)
            {

                //Vector3 pos = new Vector3(hit.point.x, 4.413f/* m_MoveObject.GetComponent<Model>().m_FinalPos.y*/, hit.point.z);
                m_MoveObject.transform.position = hit.point - new Vector3(0, m_disToUpFloor, 0);
            }
            else
                m_MoveObject.transform.position = hit.point;
        }
       
        if (Input.GetMouseButton(0))
        {
            if (bHit)
            {
                if ("Finish" == hit.transform.tag)
                {
                    m_MoveObject.GetComponent<Model>().ToRightPos();
                    m_MoveObject.GetComponent<Model>().ActionStart();
                    
                    m_MoveObject = null;
                }
            }
        }
    }
    
}
