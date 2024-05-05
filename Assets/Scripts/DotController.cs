using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DotController : MonoBehaviour
{
    private int _id;
    private string _spritePath;
    private byte[] _bytes;
    public Sprite _sprite;

    public void SetId(int dotId){
        this._id = dotId;
        _spritePath=Path.Combine(Application.streamingAssetsPath, "Images");
        var files = Directory.GetFiles(_spritePath);
        if (files.Length > 0) {
            var path = Path.Combine(_spritePath, $"{_id}" + ".png");
            var file = new FileInfo(path);
            if (file.Exists) {
                _bytes = File.ReadAllBytes(path);
                var texture = new Texture2D(1024, 1024, TextureFormat.BC5, false, true);
                texture.LoadImage(_bytes);
                _sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            }
            else {
                Debug.Log("Под точку " + dotId + " не найдено изображения");
            }
        }
        else {
            Debug.Log("Папка с изображениями пуста");
        }
    }
        
    public void OnPointerClick() {
        gameObject.GetComponentInParent<CreateDot>().SetImage(_sprite);
    }
}
