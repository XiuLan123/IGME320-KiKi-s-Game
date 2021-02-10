using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public const int MAX_HP = 100;
    public int currentHP = 100;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = MAX_HP;
        healthBar.SetMaxHealth(MAX_HP);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }

    void TakeDamage(int damage)
    {
        currentHP -= damage;
        healthBar.SetHealth(currentHP);
    }
}
