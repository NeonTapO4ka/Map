using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayCastUI : MonoBehaviour
{
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        RayCastHit();
    }
    void RayCastHit()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (GetComponent<Collider>().Raycast(ray, out hit, 10000f))
        {
            transform.localScale = Vector3.one * 1.2f;
            GetComponent<CanvasRenderer>().SetColor(Color.yellow);
            if (Input.GetMouseButtonDown(0))
            {
                GetComponent<Button>().onClick.Invoke();
            }


        }
        else
        {
            transform.localScale = Vector3.one * 1f;
            GetComponent<CanvasRenderer>().SetColor(Color.white);

        }
    }
}
