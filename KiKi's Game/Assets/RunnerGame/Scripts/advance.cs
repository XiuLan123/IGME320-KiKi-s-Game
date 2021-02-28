using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    public class advance : MonoBehaviour
    {
        public static float speed = 10f;
        private float augment = 0.0f;
        // Start is called before the first frame update
        void Start()
        {
            if (gameObject.CompareTag("Road"))
            {
                augment = -5f;
            }
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x,
                                                        gameObject.transform.position.y,
                                                        gameObject.transform.position.z - (speed + augment) * Time.deltaTime);
            if (gameObject.transform.position.z < -5.9)
            {
                if (!gameObject.CompareTag("Road"))
                    SpawnCars.spawnedObjects.Remove(this.gameObject);
                else
                {
                    GameObject g = Instantiate(GameManager.roadPrefab, new Vector3(0.0f, 0.5f, 54.0f), Quaternion.identity);
                }
                Destroy(this.gameObject);
                
            }
        }

        public static void IncreaseSpeed(float value)
        {
            speed += value;
        }
    }
}
