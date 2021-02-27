using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    public class Advance : MonoBehaviour
    {
        public static float speed = 15f;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x,
                                                        gameObject.transform.position.y,
                                                        gameObject.transform.position.z -  Time.deltaTime * speed);
            if (gameObject.transform.position.z < -5)
            {
                SpawnCars.spawnedObjects.Remove(this.gameObject);
                Destroy(this.gameObject);
            }
        }

        public static void IncreaseSpeed(float value)
        {
            speed += value;
        }
    }
}
