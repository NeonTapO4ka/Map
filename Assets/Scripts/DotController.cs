using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DotController : MonoBehaviour
{
    public Image img;
    private int id;
    private string spritePath;
    byte[] bytes;
    Sprite sprite;
 
    public void SetId(int DotId){
        this.id = DotId;
        spritePath=Path.Combine(Application.streamingAssetsPath, "Images");
        string[] files = Directory.GetFiles(spritePath);
        if (files.Length > 0)
        {
            var path = Path.Combine(spritePath, $"{id}" + ".png");
            var file = new FileInfo(path);
            if (file.Exists)
            {
                bytes = File.ReadAllBytes(path);
                var texture = new Texture2D(1024, 1024, TextureFormat.BC5, false, true);
                texture.LoadImage(bytes);
                sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            }
            else
            {
                Debug.Log("Под точку " + DotId + " не найдено изображения");
            }
            img.sprite = sprite;
            img.rectTransform.sizeDelta = new Vector2(200, 200);
        }
        else
        {
            Debug.Log("Папка с изображениями пуста");
        }
        
        
    }
        
    public void OnPointerClick(){
        img.gameObject.SetActive(!img.gameObject.activeSelf);
    }
}
