using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RunnerGame
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager m_instance;
        public int score = 0;
        public Text scoreText;
        [SerializeField]
        private GameObject road_Prefab;
        public static GameObject roadPrefab;
        public Image gameOverImage;
        public static bool dead = false;

        // Start is called before the first frame update
        void Start()
        {
            m_instance = this;
            roadPrefab = road_Prefab;
            StartCoroutine(IncreaseScore());
            StartCoroutine(WearDownBike());
        }

        public void GameOver()
        {
            StopAllCoroutines();
            dead = true;
            gameOverImage.gameObject.SetActive(true);
        }

        public IEnumerator IncreaseScore()
        {
            yield return new WaitForSeconds(1f);
            AddScore(2);
            StartCoroutine(IncreaseScore());
        }
        public void AddScore(int toAdd)
        {
            score += toAdd;
            scoreText.text = $"{score} pts.";
        }
        public IEnumerator WearDownBike()
        {
            yield return new WaitForSeconds(0.1f);
            Player.TakeDamage(0.1f);
            StartCoroutine(WearDownBike());
        }
    }
}
