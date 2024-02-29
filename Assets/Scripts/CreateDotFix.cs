
using System.IO;
using UnityEngine;
using System.Xml.Linq;
using System.Text.RegularExpressions;

public class CreateDotFix : MonoBehaviour
{
    private void Update(){
        if (GameObject.FindGameObjectsWithTag("Image").Length > 1){
            GameObject.FindGameObjectWithTag("Image").SetActive(false);
        }
    }

    public GameObject DotOrigin;
    private GameObject Dot;
    XDocument xdoc;
    string xName = Path.Combine(Application.streamingAssetsPath ,"Xml");
    int mapSizeX = 3374;
    int mapSizeY = 3374;
    float offsetX = 29;
    float offsetY = 253;
    private int DotId=0;
    private float ConvertToMercatorY(float lat){

        float latRad = lat * (float)(Mathf.PI / 180);
        float mercN = Mathf.Log(Mathf.Tan((float)(Mathf.PI / 4) + (latRad / 2)));
        float y = (mapSizeY / 2) - (float)(mapSizeY * mercN / (2 * Mathf.PI));
        return y;
    }
    public void OnClick(){
        if (!Directory.Exists(xName)){
            Debug.LogError("Невозможно получить доступ к: " + xName);
            return;
        }
        string[] files = Directory.GetFiles(xName);
        foreach (string file in files){
            if (Path.GetExtension(file) == ".xml"){
                xdoc = XDocument.Load(file);
                var lat = xdoc.Element("SPP_ROOT").Element("Geographic").Element("aNWLat").Value.ToString();
                var lon = xdoc.Element("SPP_ROOT").Element("Geographic").Element("aNWLong").Value.ToString();
                Debug.Log("сыро 1:  "+ lat);
                Debug.Log("сыро 2:  " + lon);
                float[] coorRes = new float[2];
                Regex reg = new Regex(":");
                string latS1 = lat.Substring(0, lat.ToString().Length - 1).Replace(".", "");
                string latS2 = reg.Replace(latS1, ",", 1);
                string latS3 = latS2.Replace(":", "");
                coorRes[0] = float.Parse(latS3);
                string lonS1 = lat.Substring(0, lon.ToString().Length - 1).Replace(".", "");
                string lonS2 = reg.Replace(lonS1, ",", 1);
                string lonS3 = lonS2.Replace(":", "");
                coorRes[1] = float.Parse(lonS3);
                coorRes[1] = float.Parse(reg.Replace(lon.Substring(0, lon.ToString().Length - 2).Replace(".", ""), ",", 1).Replace(":", ""));
                float x = (float)(coorRes[1] + 180) * ((float)mapSizeX / 360);
                Vector3 position = new Vector3(x - offsetX - (mapSizeX / 2), (ConvertToMercatorY(-coorRes[0]) + 0.6f - offsetY - (mapSizeY / 2)), 0);
                Debug.Log(position);
                Dot = Instantiate(DotOrigin, position, Quaternion.identity);
                Dot.transform.SetParent(this.transform, false);
                Dot.GetComponent<DotController>().SetId(DotId);
                DotId++;
                
            }
        }
    }
    
    public void OnClickDestroy(){
        foreach(GameObject go in GameObject.FindGameObjectsWithTag("Dot")){
            Destroy(go);
        }
    }
}
