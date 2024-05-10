using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;


public class DisplayObjectInfo : MonoBehaviour
{
    [SerializeField] private int size = 90;
    private float _posX;
    private float _posY;
    public TMP_Text _textInfo;
    
     
    
    public Camera droneCamera; 
    private Ray ray; 
    private RaycastHit hit; 

    void Update()
    {
        ray = droneCamera.ScreenPointToRay(Input.mousePosition); 

        if (Physics.Raycast(ray, out hit))
        {
            DisplayInfo(hit.collider.gameObject);
        }
        else
        {
            _textInfo.text = ""; 
        }
    }

    void DisplayInfo(GameObject obj)
    {
        string filePath = null;

        if (obj.CompareTag("Ship"))
        {
            filePath = Path.Combine(Application.streamingAssetsPath, $"Info/ship"+obj.GetComponent<ObjectController>().id+".txt");
            
        }
        else if (obj.CompareTag("Base"))
        {
            filePath = Path.Combine(Application.streamingAssetsPath, "Info/base"+ obj.GetComponent<ObjectController>().id+".txt");
        }
        if (File.Exists(filePath))
        {
            _textInfo.text = File.ReadAllText(filePath);
            Debug.Log(_textInfo.text);
        }
        else
        {
            _textInfo.text = "";
        }

    }
    
    /*public void OnGUI(){   
        
        _posX = Screen.width/2.0f - size/16.0f;
        _posY = Screen.height/2.0f+200 - size/8.0f;
        GUI.color=Color.black;
        GUI.Label (new Rect (_posX, _posY, size, size), _textInfo);
    }*/
}

