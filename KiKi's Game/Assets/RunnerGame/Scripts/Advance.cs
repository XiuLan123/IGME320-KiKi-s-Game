using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    public class Advance : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (gameObject.transform.position.z <= -3)
                gameObject.transform.position = new Vector3(gameObject.transform.position.x,
                                                        gameObject.transform.position.y,
                                                        45);
            else
                gameObject.transform.position = new Vector3(gameObject.transform.position.x,
                                                            gameObject.transform.position.y,
                                                            gameObject.transform.position.z - 0.05f);
        }
    }
}
