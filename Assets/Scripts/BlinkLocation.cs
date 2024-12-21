using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkLocation : MonoBehaviour
{
    [HideInInspector]
    public Transform target;
   
    [HideInInspector]
    public MeshRenderer m_Renderer;

    void Start()
    {
        target = transform.GetChild(0).GetComponent<Transform>(); 

        m_Renderer = GetComponent<MeshRenderer>();
    }
}
