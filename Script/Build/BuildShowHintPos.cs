using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildShowHintPos : Build {
    public UnityEngine.UI.Text obj_HintObj;
    public string m_HintText;
    public Vector3 m_WorldPos;

    public override void Init()
    {
        obj_HintObj.text = m_HintText;
        obj_HintObj.gameObject.SetActive(true);
        obj_HintObj.transform.position = Camera.main.WorldToScreenPoint(m_WorldPos);
        Invoke("End", 1);
    }
    public override void End()
    {
        obj_HintObj.gameObject.SetActive(false);
        base.End();

    }
    public override void Reset()
    {
        base.Reset();
        obj_HintObj.gameObject.SetActive(false);
        CancelInvoke();
    }
}
