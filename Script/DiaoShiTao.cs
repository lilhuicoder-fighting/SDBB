using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaoShiTao : MonoBehaviour {
    public Transform[] ShiTou;
    Vector3[] m_ShiPos;
    private void Start()
    {
        m_ShiPos = new Vector3[ShiTou.Length];
        for(int i=0;i<ShiTou.Length;++i)
        {
            m_ShiPos[i] = ShiTou[i].transform.position;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "WaJueJi")
        {
           
            for(int i= 0;i<ShiTou.Length;++i)
            {
                ShiTou[i].GetComponent<Rigidbody>().useGravity = true;
                ShiTou[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            }
            enabled = false;
        }
    }
    //private void OnDisable()
    //{
    //    for (int i = 0; i < ShiTou.Length; ++i)
    //    {
    //        ShiTou[i].GetComponent<Rigidbody>().useGravity = false;
    //        ShiTou[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    //        ShiTou[i].transform.position = m_ShiPos[i];
    //    }
    //}
    public virtual void Reset()
    {
        for (int i = 0; i < ShiTou.Length; ++i)
        {
            ShiTou[i].GetComponent<Rigidbody>().useGravity = false;
            ShiTou[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            ShiTou[i].transform.position = m_ShiPos[i];
        }
    }
}
