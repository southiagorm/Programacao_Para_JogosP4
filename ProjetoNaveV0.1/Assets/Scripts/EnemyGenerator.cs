using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject prefabInimigo;

    void Start()
    {
        InvokeRepeating("GerarInimigo", 1, 2);    
    }

    public void GerarInimigo()
    {
        float posX = Random.Range(-10, 10);

        Vector3 position = new Vector3(posX, transform.position.y,0);

        Instantiate(prefabInimigo, position, Quaternion.identity);
    }
}
