using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildWait : Build
{
    public float m_WaitTime;
    public override void Init()
    {
        Invoke("End", m_WaitTime);
    }
    public override void Reset()
    {
        base.Reset();
        CancelInvoke();
    }
}
