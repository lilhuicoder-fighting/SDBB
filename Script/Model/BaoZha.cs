using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaoZha : MonoBehaviour {
    public Vector3 m_CenterPos;
    public float m_Force;
    private void OnEnable()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 forceDic =transform.position -  m_CenterPos;
        rb.AddForce(forceDic* m_Force);
    }
   
}
