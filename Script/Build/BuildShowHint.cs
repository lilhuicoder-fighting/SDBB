using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildShowHint : Build {
    public ShowHint obj_HintObj;
    //public UnityEngine.UI.Text obj_HintText;
    public string m_HintText;

    public override void Init()
    {
        //obj_HintText.text = m_HintText;
        obj_HintObj.Show(m_HintText);
        Invoke("End", 1);
    }

    public override void Reset()
    {
        base.Reset();
        CancelInvoke();
        obj_HintObj.Hide();
    }
}
