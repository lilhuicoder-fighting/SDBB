using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabUI : MonoBehaviour {
    public Image[] obj_tabBut;
    public GameObject[] obj_tabContent;
    public Sprite[] m_SpriteSelected;
    public Sprite[] m_SpriteUnSelected;
    int m_curTab;
	// Use this for initialization
	void Start () {
        //m_curTab = 0;
	}
	

    public void OnClickOneTab()
    {
        ShowTab(0);
    }

    public void OnClickTwoTab()
    {
        ShowTab(1);
    }

    public void OnClickThreeTab()
    {
        ShowTab(2);
    }
    //显示或关闭某一栏
    void ShowTab(int i)
    {
        if (i == m_curTab)
            return;
        obj_tabContent[i].SetActive(true);
        obj_tabContent[m_curTab].SetActive(false);
        obj_tabBut[i].sprite = m_SpriteSelected[i];
        obj_tabBut[m_curTab].sprite = m_SpriteUnSelected[m_curTab];
        m_curTab = i;
    }
}
