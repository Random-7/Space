using UnityEngine;
using UnityEngine.UI;
 
public class BGScroller : MonoBehaviour {
    [SerializeField] Texture[] sourceImages;
    [SerializeField] RawImage img;
    [SerializeField] float x, y;

    void Awake()
    {
        img.texture = sourceImages[Random.Range(0,sourceImages.Length-1)];
    }
 
    void Update()
    {
        img.uvRect = new Rect(img.uvRect.position + new Vector2(x,y) * Time.deltaTime, img.uvRect.size);
    }
}