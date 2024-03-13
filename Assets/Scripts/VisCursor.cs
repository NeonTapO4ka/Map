using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisCursor : MonoBehaviour
{
    private Camera mainCamera;
    private bool isCursorHidden = true;
    
    void Start()
    {
        mainCamera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void OnGUI(){   
        int size = 90;
        float posX = Screen.width/2 - size/16;
        float posY = Screen.height/2 - size/8;
        GUI.color=Color.black;
        GUI.Label (new Rect (posX, posY, size, size), "+");
    }
    
}
    
