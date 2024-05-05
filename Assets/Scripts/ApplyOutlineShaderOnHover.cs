using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ApplyOutlineShaderOnHover : MonoBehaviour
{
    public Shader outlineShader; 
    private Renderer rend;
    
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void OnMouseEnter()
    {
        if (gameObject.CompareTag("Ship")|| gameObject.CompareTag("Base"))
        {
            ApplyShader();
        }
    }

    void OnMouseExit()
    {
        if (gameObject.CompareTag("Ship") || gameObject.CompareTag("Base"))
        {
            RemoveShader();
        }
    }

    void ApplyShader()
    {
        rend.material.shader = outlineShader;
    }

    void RemoveShader()
    {
        rend.material.shader = Shader.Find("Standard");
    }
    
}