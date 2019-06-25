using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTexture : MonoBehaviour {
    private Renderer m_Render;
    private RaycastHit m_Hit;
    public Texture2D m_Kong;
    public Transform m_KongPos;
	// Use this for initialization
	void Start () {
        m_Render = GetComponent<Renderer>();
        AddKong();
	}
	/// <summary>
    /// 孔的位置与模型的UV有关。
    /// </summary>
	void AddKong()
    {
        if(Physics.Raycast(m_KongPos.position,m_KongPos.forward,out m_Hit))
        {
            if (!m_Hit.collider.name.Contains("xiuzheng"))
                return;
            GameObject o = Instantiate(m_KongPos.gameObject);
            o.transform.position = m_Hit.point;
            Debug.Log("AddKong");
            Texture2D texture = (Texture2D)m_Render.material.mainTexture;
            Vector2 point = m_Hit.textureCoord;
            point.x *= texture.width;
            point.y *= texture.height;
            //GetComponent<Mesh>().uv[0];
            Vector2[] uv = GetComponent<MeshFilter>().mesh.uv;

            for(int i = 0;i<uv.Length;++i)
                Debug.Log("uv["+i+"]:" + uv[i]);
            point.x -= uv[1].x;
            point.y += uv[1].y;
            Debug.Log("point:" + point);
            
            //texture.SetPixels((int)point.x, (int)point.y, bolt.width, bolt.height, bolt.GetPixels());

            for (int i = 0; i < m_Kong.width; i++)
            {
                for (int j = 0; j < m_Kong.height; j++)
                {
                    Color c = m_Kong.GetPixel(i, j);
                    if (c.a >= 0.01f)
                    {
                        Debug.Log("Color:" + c);
                        texture.SetPixel((int)point.x + i, (int)point.y + j,Color.green);
                    }
                }
            }
            texture.Apply();
        }
    }
}
