using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 过段时间自动消失
/// </summary>
public class ShowHint : MonoBehaviour {
    public UnityEngine.UI.Text obj_Text;
    public GameObject obj_SureBut;
    /// <summary>
    /// 显示后两秒钟关闭
    /// </summary>
    public void ShowHideIn2S(string s)
    {
        Show(s);
        obj_SureBut.SetActive(false);
        Invoke("Hide", 2);
    }
    //一直显示
    public void Show(string s)
    {
        CancelInvoke();
        obj_SureBut.SetActive(true);
        gameObject.SetActive(true);
        obj_Text.text = s;
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    
}
