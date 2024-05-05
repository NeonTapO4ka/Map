using UnityEngine;
public class VisCursor : MonoBehaviour {
    [SerializeField] private int size = 90;
    private float _posX;
    private float _posY;
    private void Start(){
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void OnGUI(){   
        
        _posX = Screen.width/2.0f - size/16.0f;
        _posY = Screen.height/2.0f - size/8.0f;
        GUI.color=Color.black;
        GUI.Label (new Rect (_posX, _posY, size, size), "+");
    }
}
    
