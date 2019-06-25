using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepManager : MonoBehaviour {
    public Sprite m_SpriteSelected;
    public Sprite m_SpriteUnSelected;
    public UnityEngine.UI.Image[] obj_Step;
    int m_CurStep;
	// Use this for initialization
	public void Init () {
        m_CurStep = 0;
	}
	public void SetStep(int i)
    {
        if (i < 0 || i > obj_Step.Length - 1)
            return;
        obj_Step[m_CurStep].sprite = m_SpriteUnSelected;
        obj_Step[i].sprite = m_SpriteSelected;
        m_CurStep = i;
    }
    public int GetTotleStep()
    {
        return obj_Step.Length;
    }
}
