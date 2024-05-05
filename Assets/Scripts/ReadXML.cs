using System.Text.RegularExpressions;
using System.Xml.Linq;
using UnityEngine;

public class ReadXML : MonoBehaviour
{
    private const int MapSizeX = 3374;
    private const int MapSizeY = 3374;
    private const float OffsetX = 29;
    private const float OffsetY = 253;
    
    private static float ConvertToMercatorY(float lat){
        
            var latRad = lat * (Mathf.PI / 180);
            var mercN = Mathf.Log(Mathf.Tan((Mathf.PI / 4) + (latRad / 2)));
            var y = (MapSizeY / 2.0f) - (MapSizeY * mercN / (2 * Mathf.PI));
            return y;
    }

    public static Vector3 GetPosition(string file)
    {
        
        var xDoc = XDocument.Load(file);
        var lat = xDoc.Element("SPP_ROOT").Element("Geographic").Element("aNWLat").Value;
        var lon = xDoc.Element("SPP_ROOT").Element("Geographic").Element("aNWLong").Value;
        var coorRes = new float[2];
        var reg = new Regex(":");
        var latS1 = lat.Substring(0, lat.Length - 1).Replace(".", "");
        var latS2 = reg.Replace(latS1, ",", 1);
        var latS3 = latS2.Replace(":", "");
        coorRes[0] = float.Parse(latS3);
        var lonS1 = lat[..(lon.Length - 1)].Replace(".", "");
        var lonS2 = reg.Replace(lonS1, ",", 1);
        var lonS3 = lonS2.Replace(":", "");
        coorRes[1] = float.Parse(lonS3);
        coorRes[1] = float.Parse(reg.Replace(lon[..^2].Replace(".", ""), ",", 1).Replace(":", ""));
        var x = (coorRes[1] + 180.0f) * (MapSizeX / 360.0f);
        var position = new Vector3(x - OffsetX - (MapSizeX / 2.0f)-960, (ConvertToMercatorY(-coorRes[0]) + 0.6f - OffsetY - (MapSizeY / 2.0f))-480-60, 0); 
        return position;
    }
}
