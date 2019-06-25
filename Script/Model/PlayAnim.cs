using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnim : Model {
    bool m_Play;
    Animation m_Anim;
    private void Start()
    {
        m_Play = false;
        m_Anim = GetComponent<Animation>();
    }
    private void Update()
    {
        if (!m_Play)
            return;
        if(!m_Anim.isPlaying)
        {
            ActionStop();
        }
    }
    public override void ActionStart()
    {
        m_Anim.Play();
        m_Play = true;
    }
    public override void ActionStop()
    {
        base.ActionStop();
        Destroy(gameObject);
    }
}
