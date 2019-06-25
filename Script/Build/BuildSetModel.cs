using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSetModel : Build {
    public Vector3 m_TargetPos;
    public Vector3 m_TargetAngle;
    public Transform obj_SetModel;
    public GameObject obj_Hint;
    public override void Init()
    {
        obj_SetModel.transform.position = m_TargetPos;
        obj_SetModel.transform.eulerAngles = m_TargetAngle;
    }

    // Update is called once per frame
    void Update () {
        
    }
    public virtual void ToEnd()
    {
        obj_Hint.SetActive(false);
        base.End();
    }
    public void ShowText(string a)
    {
        ShowText(a, m_TargetPos);
    }
    public void ShowText(string a,Vector3 pos)
    {
        Vector2 screenPos = Camera.main.WorldToScreenPoint(pos);
        obj_Hint.GetComponent<UnityEngine.UI.Text>().text = a;
        obj_Hint.SetActive(true);
        obj_Hint.transform.position = new Vector3(screenPos.x, screenPos.y, 0);
    }
    public override void Reset()
    {
        Init();
        obj_Hint.SetActive(false);
    }
}
