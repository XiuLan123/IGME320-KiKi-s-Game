using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomMovement : MonoBehaviour
{
    public int dir = -1;
    public float rotationSpeed = 30f;
    public float directionTimer = 3f;
    float maxRotation = 20;
    float rotation = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (directionTimer <= 0)
        {
            directionTimer = Random.Range(1f, 6f);
            rotationSpeed = Random.Range(20f, 50f);
            dir *= -1;
        }

        rotation += rotationSpeed * dir * Time.deltaTime;

        rotation = Mathf.Clamp(rotation, -maxRotation, maxRotation);

        transform.rotation = Quaternion.AngleAxis(rotation, Vector3.forward);

        directionTimer -= Time.deltaTime;
    }
}
