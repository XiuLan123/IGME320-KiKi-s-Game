using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RunnerGame
{
    public class GameManager : MonoBehaviour
    {
        public int score = 0;
        public Text scoreText;

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(IncreaseScore());
            StartCoroutine(WearDownBike());
        }

        public void GameOver()
        {
            StopAllCoroutines();
            GameNavigation.GoToMainMenu();
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
