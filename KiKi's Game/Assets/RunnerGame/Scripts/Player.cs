using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    public class Player : MonoBehaviour
    {
        public const int MAX_HP = 100;
        public float currentHP = 100;

        public HealthBar healthBar;
        public GameManager gm;
        private static Player m_instance;
        // Start is called before the first frame update
        void Start()
        {
            currentHP = MAX_HP;
            healthBar.SetMaxHealth(MAX_HP);
            m_instance = this;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                TakeDamage(20f);
            }
        }



        public static void TakeDamage(float damage)
        {
            m_instance.currentHP -= damage;
            if (m_instance.currentHP > 100)
                m_instance.currentHP = 100;
            m_instance.healthBar.SetHealth(m_instance.currentHP);
            if (m_instance.currentHP <= 0)
            {
                m_instance.gm.GameOver();
            }
        }


        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Pickup")
            {
                gm.AddScore(5);
                TakeDamage(-5);
            }
            else
                TakeDamage(10);
        }
    }
}
