using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectPlayerSprite : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private GameObject leftBtn;
    [SerializeField] private GameObject rightBtn;
    public Sprite[] sprite;
    public static int spriteID;

    void Start()
    {
        SetFirstSprite();
    }

    void Update()
    {
        CheckSpriteArray();
    }

    public void LeftButton()
    {
        spriteID -= 1;
        image.sprite = sprite[spriteID];
    }
    
    public void RightButton()
    {
        spriteID += 1;
        image.sprite = sprite[spriteID];
    }

    private void SetFirstSprite()
    {
        image.sprite = sprite[0];
        spriteID = 0;
    }

    private void CheckSpriteArray()
    {
        if (spriteID == 0)
        {
            leftBtn.SetActive(false);
            rightBtn.SetActive(true);
        }
        else if (spriteID == 3)
        {
            leftBtn.SetActive(true);
            rightBtn.SetActive(false);
        }
        else
        {
            leftBtn.SetActive(true);
            rightBtn.SetActive(true);
        }
    }
}
