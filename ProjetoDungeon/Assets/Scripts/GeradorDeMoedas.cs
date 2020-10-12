using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeMoedas : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabMoeda;

    [SerializeField]
    private float time;
    [SerializeField]
    private float timeRate;

    void Start()
    {
        InvokeRepeating("GerarMoeda", time, timeRate);
    }

    public void GerarMoeda()
    {
        float x = Random.Range(-10.8f, 10.8f);
        float y = Random.Range(-4.8f, 4.8f);

        Instantiate(prefabMoeda, new Vector2(x,y), Quaternion.identity);
    }
}
