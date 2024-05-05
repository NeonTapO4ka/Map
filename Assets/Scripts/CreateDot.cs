using System.IO;
using UnityEngine;
using System.Xml.Linq;
using UnityEngine.UI;

public class CreateDot : MonoBehaviour {
        public GameObject dotOrigin;
        private GameObject _dot;
        private XDocument _xDoc;
        private readonly string _xName = Path.Combine(Application.streamingAssetsPath ,"Xml");
        private int _dotId=0;
    public Image img;
    public static int CheckDots(){
        if (GameObject.FindGameObjectsWithTag("Image").Length > 1){
            GameObject.FindGameObjectWithTag("Image").SetActive(false);
        }
        return 0;
    }
    public void OnClick(){
        
        if(GameObject.FindGameObjectsWithTag("Dot").Length>0) {
            Debug.Log("Точки уже на экране, удалите их");
        }
        else {
            if (!Directory.Exists(_xName)) {
                Directory.CreateDirectory(_xName);
                return;
            }
            var files = Directory.GetFiles(_xName);
            if (files.Length > 0) {
                foreach (var file in files) {
                    if (Path.GetExtension(file) != ".xml") continue;
                    _dot = Instantiate(dotOrigin, ReadXML.GetPosition(file), Quaternion.identity);
                    _dot.transform.SetParent(this.transform, false);
                    _dot.GetComponent<DotController>().SetId(_dotId);
                    _dotId++;
                }
            }
            else {
                Debug.Log("Папка Xml пуста");
            }
        }
    }
    public void OnClickDestroy(){
        foreach(GameObject go in GameObject.FindGameObjectsWithTag("Dot")){
            Destroy(go);
        }
        _dotId = 0;
    }
    public void SetImage(Sprite sprite)
    {
        
        img.sprite = sprite;
        img.rectTransform.sizeDelta = new Vector2(500, 700);
    }
}
