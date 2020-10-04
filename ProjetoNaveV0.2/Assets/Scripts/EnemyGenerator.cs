using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject[] prefabInimigo;

    void Start()
    {
        InvokeRepeating("GerarInimigo", 1, 1.2f);    
    }

    public void GerarInimigo()
    {
        float posX = Random.Range(-10, 10);

        Vector3 position = new Vector3(posX, transform.position.y,0);

        Instantiate(GerarPrefabInimigo(), position, Quaternion.identity);
    }

    public GameObject GerarPrefabInimigo()
    {
        int valor = Random.Range(0, 101);
        if(valor >= 60)
        {
            return prefabInimigo[0];
        }else
        {
            return prefabInimigo[1];
        }
    }
}
