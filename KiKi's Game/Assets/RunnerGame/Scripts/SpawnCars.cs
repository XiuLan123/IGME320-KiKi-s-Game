using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    public class SpawnCars : MonoBehaviour
    {
        [System.Flags]
        public enum Lanes
        {
            None = 0,   //must have a specified 0
            Right = 1 << 0,    //1 = 001
            Middle = 1 << 1,    //2 = 010
            Left = 1 << 2,   //4 = 100
        }

        static System.Random rng;
        public GameObject leftSpawner;
        public GameObject middleSpawner;
        public GameObject rightSpawner;

        public GameObject sedanPrefab;
        public GameObject euroPrefab;
        public GameObject itemPrefab;

        public static List<GameObject> spawnedObjects;
        private Lanes lanesUsed = Lanes.None;

        [SerializeField]
        private float level;
        [SerializeField]
        private float timeElapsedInLevel;
        [SerializeField]
        private float AvdSpd;

        private float minWait, maxWait;

        private float timeSinceLastItem;
        private float timePerItem;
        // Start is called before the first frame update
        void Start()
        {
            rng = new System.Random();
            spawnedObjects = new List<GameObject>();
            timeSinceLastItem = 0;
            timePerItem = 2.235f;
            timeElapsedInLevel = 0.0f;
            level = 1;
            StartCoroutine(SpawnWave());
            AvdSpd = Advance.speed;

            minWait = 0.5f;
            maxWait = 1.5f;
        }

        // Update is called once per frame
        void Update()
        {
            timeSinceLastItem += Time.deltaTime;
            timeElapsedInLevel += Time.deltaTime;

            if (timeElapsedInLevel > 10.0f)
            {
                level++;
                Advance.IncreaseSpeed(0.02f);
                AvdSpd = Advance.speed;
                timeElapsedInLevel = 0;

                minWait = minWait - 0.05f;
                if (minWait < 0.2f)
                    minWait = 0.2f;
                maxWait = maxWait - 0.3f;
                if (maxWait < 0.3f)
                    maxWait = 0.3f;
                if (level == 5)
                {
                    ControlMovement.lerpDuration = 0.05f;
                }
            }
        }

        IEnumerator SpawnWave()
        {
            lanesUsed = Lanes.None;
            Lanes putInLane;

            //determine how long to wait before spawning next wave
            float waitTime = (float)(rng.NextDouble() * (maxWait - minWait) + minWait);
            yield return new WaitForSeconds(waitTime);

            //how many cars in this wave? One or Two?
            int numCars = rng.Next(1, 3);

            // Spawning Cars //
            for (int i = 0; i < numCars; i++)
            {
                //determine what car prefab to use
                float num = rng.Next(0, 3);
                GameObject randPrefab;
                if (num > 0)
                    randPrefab = sedanPrefab;
                else
                    randPrefab = euroPrefab;

                //determine what AVAILABLE lane it goes in
                do
                {
                    putInLane = (Lanes)(1 << rng.Next(0, 3));
                } while ((lanesUsed & putInLane) == putInLane);
                lanesUsed = lanesUsed | putInLane;
                switch (putInLane)
                {
                    case Lanes.Right:
                        SpawnInLane(randPrefab, rightSpawner);
                        break;
                    case Lanes.Middle:
                        SpawnInLane(randPrefab, middleSpawner);
                        break;
                    case Lanes.Left:
                        SpawnInLane(randPrefab, leftSpawner);
                        break;
                }                
            }

            // Spawning Items //
            if (timeSinceLastItem > timePerItem)
            {
                timeSinceLastItem = 0;
                do
                {
                    putInLane = (Lanes)(1 << rng.Next(0, 3));
                } while ((lanesUsed & putInLane) == putInLane);
                switch (putInLane)
                {
                    case Lanes.Right:
                        SpawnInLane(itemPrefab, rightSpawner);
                        break;
                    case Lanes.Middle:
                        SpawnInLane(itemPrefab, middleSpawner);
                        break;
                    case Lanes.Left:
                        SpawnInLane(itemPrefab, leftSpawner);
                        break;
                }
            }
            StartCoroutine(SpawnWave());
        }

        private void SpawnInLane(GameObject prefab, GameObject spawner)
        {
            spawnedObjects.Add(GameObject.Instantiate(prefab, spawner.transform));
        }
    }
}
