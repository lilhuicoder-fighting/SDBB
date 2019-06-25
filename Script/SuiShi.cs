using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuiShi : MonoBehaviour {
    public GameObject obj_SuiShi;
    public Transform[] obj_KongPos;
    public string[] m_KongName;
    public Transform obj_Hint;
    public UnityEngine.UI.Text obj_Text;
    int m_CurHintIndex;
    GameObject obj_CreatedShi;
    void ShowHint()
    {
        if (m_CurHintIndex >= obj_KongPos.Length)
        {
            obj_Hint.gameObject.SetActive(false);
            CancelInvoke("ShowHint");
            return;
        }
        obj_Hint.position = Camera.main.WorldToScreenPoint(obj_KongPos[m_CurHintIndex].position);
        obj_Text.text = m_KongName[m_CurHintIndex];
        ++m_CurHintIndex;
    }
    private void OnEnable()
    {
        obj_CreatedShi = Instantiate(obj_SuiShi);
        obj_CreatedShi.SetActive(true);
        obj_CreatedShi.transform.parent = gameObject.transform;
        m_CurHintIndex = 0;
        obj_Hint.gameObject.SetActive(true);
        InvokeRepeating("ShowHint", 0, 0.5f);
    }
    // Update is called once per frame

    private void OnDisable()
    {
        obj_CreatedShi.GetComponent<SuiShiZhaKai>().Reset();
        Destroy(obj_CreatedShi);
    }

    public GameObject GetCreatedShi()
    {
        return obj_CreatedShi;
    }
}
