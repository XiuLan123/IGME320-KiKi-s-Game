using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCamFollow : MonoBehaviour
{
    public Transform target;
    public float xMin;
    public float yMin;
    public float xMax;
    public float yMax;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax), Mathf.Clamp(target.position.y, yMin, yMax), transform.position.z);
    }
}
