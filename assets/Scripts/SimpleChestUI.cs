using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SimpleChestUI : MonoBehaviour
{
    public Sprite closedSprite;
    public Sprite openSprite;

    private Image img;

    private void Awake()
    {
        img = GetComponent<Image>();
        Close();                      
    }

    public void Open()  => img.sprite = openSprite;
    public void Close() => img.sprite = closedSprite;
}