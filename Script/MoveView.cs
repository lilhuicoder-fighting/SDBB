using System.Collections;
using System.Collections.Generic;
using UnityEngine;  

public class MoveView : MonoBehaviour {

    public Transform obj_playerPos;    //摄像机位置
    public Transform obj_playerDic; //摄像机朝向
    public float m_speed;

    Vector3 m_StartPos;//摄像机默认位置
    Quaternion m_StartDic;//摄像机默认视角
    private void Start()
    {
        m_StartPos = obj_playerPos.position;
        m_StartDic = obj_playerDic.localRotation;
    }

    // Update is called once per frame
    void Update ()
    {
        if(Input.GetMouseButton(0))
        {
            obj_playerPos.Translate(-Input.GetAxis("Mouse Y") * Vector3.up * m_speed, Space.World);
            obj_playerPos.Translate(-Input.GetAxis("Mouse X") * Vector3.right * m_speed, Space.World);
        }
        if(Input.GetMouseButton(1))
        {
            obj_playerDic.Rotate(-Input.GetAxis("Mouse Y") * Vector3.right * m_speed, Space.World);
            obj_playerDic.Rotate(Input.GetAxis("Mouse X") * Vector3.up * m_speed, Space.World);
        }
        //上
        if (Input.GetKey(KeyCode.W))
        {
            obj_playerPos.Translate(obj_playerDic.forward * Time.deltaTime * m_speed);
        }
        //下
        if (Input.GetKey(KeyCode.S))
        {
            obj_playerPos.Translate(-obj_playerDic.forward * Time.deltaTime * m_speed);
        }
        //左      
        if (Input.GetKey(KeyCode.D))
        {
            obj_playerPos.Translate(obj_playerDic.right * Time.deltaTime * m_speed);
        }
        //右      
        if (Input.GetKey(KeyCode.A))
        {
            obj_playerPos.Translate(-obj_playerDic.right * Time.deltaTime * m_speed);
        }
        //if(Input.GetMouseButton(2))
        //{
        obj_playerPos.Translate(Input.GetAxis("Mouse ScrollWheel") * obj_playerDic.forward *m_speed);
        //}
	}
    //设置摄像机位置为初始位置和朝向
    public void Reset()
    {
        obj_playerPos.position =  m_StartPos;
        obj_playerDic.localRotation = m_StartDic;
    }
}
