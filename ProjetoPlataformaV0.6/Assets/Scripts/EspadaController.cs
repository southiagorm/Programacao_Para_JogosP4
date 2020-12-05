using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspadaController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Skeletton"))
        {
            LifeSkeleton.instance.LevarDano(1);
        }
    }
}
