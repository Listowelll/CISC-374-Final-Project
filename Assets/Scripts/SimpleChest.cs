using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SimpleChest : MonoBehaviour
{
    public Sprite closedSprite;
    public Sprite openSprite;

    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        CloseChest();              
    }

    public void OpenChest()      
    {
        sr.sprite = openSprite;
    }

    public void CloseChest()       
    {
        sr.sprite = closedSprite;
    }
}