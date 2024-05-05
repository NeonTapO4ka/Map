using UnityEngine;
using UnityEngine.UI;

public class RayCastUI : MonoBehaviour {
    private Camera _mainCamera;
    private Ray _ray;
    private RaycastHit _hit;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update(){
        
        RayCastHit();
    }
    
    private void RayCastHit(){
        _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        if (GetComponent<Collider>().Raycast(_ray, out _hit, 10000f)) {
            transform.localScale = Vector3.one * 1.2f;
            GetComponent<CanvasRenderer>().SetColor(Color.yellow);
            if (Input.GetMouseButtonDown(0)) {
                GetComponent<Button>().onClick.Invoke();
            }
        }
        else {
            transform.localScale = Vector3.one * 1f;
            GetComponent<CanvasRenderer>().SetColor(Color.white);
        }
    }
}
