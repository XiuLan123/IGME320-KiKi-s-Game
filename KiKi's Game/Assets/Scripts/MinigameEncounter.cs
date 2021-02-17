using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameEncounter : MonoBehaviour
{
    float lifetime = 10f;

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        if(lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void LaunchMini(string mini)
    {
        SceneManager.LoadScene(mini);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            LaunchMini(gameObject.name.Substring(1, gameObject.name.IndexOf('(') - 1));
        }
    }
}
