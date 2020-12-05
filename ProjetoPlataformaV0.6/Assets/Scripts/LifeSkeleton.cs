using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSkeleton : MonoBehaviour
{
    public static LifeSkeleton instance;

    private int life;
    [SerializeField]
    private int maxLife;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        life = maxLife;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    public void LevarDano(int dano)
    {
        life -= dano;

        if(life <= 0)
        {
            Destroy(this.gameObject);
        }

        StartCoroutine(CoroutineEfeitoDano(8));
    }

    IEnumerator CoroutineEfeitoDano(int qtdeBlink)
    {
        for(int i = 0; i < qtdeBlink; i++)
        {
            spriteRenderer.color = new Color(spriteRenderer.color.r, 
                spriteRenderer.color.g, 
                spriteRenderer.color.b, 
                0);
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.color = new Color(spriteRenderer.color.r,
                spriteRenderer.color.g,
                spriteRenderer.color.b,
                1);
            yield return new WaitForSeconds(0.1f);
        }

        spriteRenderer.color = new Color(1, 0, 0, 1);
    }
    
}
