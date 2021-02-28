using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGObj : MonoBehaviour
{
    int dir = 1;
    public float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        float scaleVariation = Random.Range(transform.localScale.x - 0.75f, transform.localScale.x - 0.25f);
        transform.localScale = new Vector3(scaleVariation, scaleVariation, scaleVariation);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        if(transform.position.x > 10)
        {
            Destroy(gameObject);
        }
    }
}
