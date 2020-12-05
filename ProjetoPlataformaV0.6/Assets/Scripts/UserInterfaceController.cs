using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterfaceController : MonoBehaviour
{
    public static UserInterfaceController instance;

    [SerializeField]
    private Image[] uiHearts;

    [SerializeField]
    private Sprite fullHeart, emptyHeart;

    void Awake()
    {
        instance = this;    
    }

    public void UpdateLifeDisplay()
    {
        for (int i = 0; i < uiHearts.Length; i++)
        {
            if (i < PlayerLife.instance.Life)
            {
                uiHearts[i].sprite = fullHeart;
            }
            else
            {
                uiHearts[i].sprite = emptyHeart;
            }
        }
    }
}
