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

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void UpdateLifeDisplay()
    {
        switch (PlayerLife.instance.Life)
        {
            case 4:
                for(int i = 0; i < uiHearts.Length; i++)
                {
                    uiHearts[i].sprite = fullHeart;
                }
                break;
            case 3:
                for (int i = 0; i < uiHearts.Length-1; i++)
                {
                    uiHearts[i].sprite = fullHeart;
                }
                uiHearts[3].sprite = emptyHeart;
                break;
            case 2:
                for (int i = 0; i < uiHearts.Length - 2; i++)
                {
                    uiHearts[i].sprite = fullHeart;
                }
                uiHearts[2].sprite = emptyHeart;
                uiHearts[3].sprite = emptyHeart;
                break;
            case 1:
                for (int i = 0; i < uiHearts.Length - 3; i++)
                {
                    uiHearts[i].sprite = fullHeart;
                }
                uiHearts[1].sprite = emptyHeart;
                uiHearts[2].sprite = emptyHeart;
                uiHearts[3].sprite = emptyHeart;
                break;
            case 0:
                for (int i = 0; i < uiHearts.Length ; i++)
                {
                    uiHearts[i].sprite = emptyHeart;
                }
                break;
        }
    }
}
