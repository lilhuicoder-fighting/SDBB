using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMenu : MonoBehaviour {
    bool m_ShowSteps;
    public GameObject obj_Steps;
    private void Start()
    {
        HideStep();
        obj_Steps.GetComponent<StepManager>().Init();
    }
    public void ClickStepBut()
    {
        if (m_ShowSteps)
            HideStep();
        else
            ShowStep();
    }
    void ShowStep()
    {
        obj_Steps.SetActive(true);
        m_ShowSteps = true;
    }
    void HideStep()
    {
        obj_Steps.SetActive(false);
        m_ShowSteps = false;
    }
}
