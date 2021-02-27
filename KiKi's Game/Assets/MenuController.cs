using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    Rigidbody2D Rb;
    public float moveSpeed;
    public bool introDone = false;
    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (introDone)
        {
            Vector3 moveStep = Vector3.zero;
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                moveStep.x -= 1;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                moveStep.x += 1;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                moveStep.y -= 1;
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                moveStep.y += 1;
            }
            moveStep.z = 0;
            moveStep.Normalize();
            Rb.AddForce(moveStep * moveSpeed);

            if (Rb.velocity.sqrMagnitude > 0.1f * 0.1f)
            {
                float rotation = Mathf.Atan2(Rb.velocity.y, Rb.velocity.x);
                transform.rotation = Quaternion.AngleAxis(Mathf.Rad2Deg * rotation, Vector3.forward);
            }
        }
    }
}
