using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{

    public static PlayerLife instance;

    [SerializeField]
    private int life;
    public int Life { get { return this.life; } }
    [SerializeField]
    private int maxLife;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        life = maxLife;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int value)
    {
        life -= value;
        if(life <= 0)
        {
            life = 0;
            gameObject.SetActive(false);
        }

        UserInterfaceController.instance.UpdateLifeDisplay();
    }
}
