using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuiShiZhaKai : DiaoShiTao
{
    //public Transform[] obj_YanShi;
    int m_CurIndex;
    int m_ZhaIndex;

	// Use this for initialization
	void Start () {
        m_CurIndex = 0;
        ZhaKai();
        m_ZhaIndex = -1;
    }
    void BaoZha()
    {
        ++m_CurIndex;
        if (m_CurIndex < ShiTou.Length)
            Invoke("ZhaKai", 0.5f);
        
    }
    /// <summary>
    /// 炸开第index层的岩石
    /// </summary>
    void ZhaKai()
    {
        //if (m_CurIndex == m_ZhaIndex)
        //    return;
        //m_ZhaIndex = m_CurIndex;
        Debug.Log("ZhaKai index = " + m_CurIndex);
        Transform obj;
        int i = 0;
        int count = ShiTou[m_CurIndex].childCount;
        for (;i<count;++i)
        {
            obj = ShiTou[m_CurIndex].GetChild(i);
            obj.GetComponent<Rigidbody>().useGravity = true;
            obj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            obj.GetComponent<BoxCollider>().enabled = true;
            obj.GetComponent<BaoZha>().enabled = true;
        }
        BaoZha();

    }

    public override void Reset()
    {
        for(int index = 0;index < ShiTou.Length;++index)
        {
            Transform obj;
            int i = 0;
            int count = ShiTou[index].childCount;
            for (; i < count; ++i)
            {
                obj = ShiTou[index].GetChild(i);
                obj.GetComponent<Rigidbody>().useGravity = false;
                obj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                obj.GetComponent<BoxCollider>().enabled = false;
                obj.GetComponent<BaoZha>().enabled = false;
            }
        }
    }
}
