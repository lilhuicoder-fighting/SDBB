using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDataBase : MonoBehaviour {
    public GameObject obj_ToolShowed;
    public GameObject obj_ToolHided;
    
    public void Show()
    {
        obj_ToolShowed.SetActive(true);
        obj_ToolHided.SetActive(false);
    }

    public void Hide()
    {
        obj_ToolShowed.SetActive(false);
        obj_ToolHided.SetActive(true);
    }
}
