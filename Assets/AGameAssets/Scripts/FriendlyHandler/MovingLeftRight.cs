using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingLeftRight : MonoBehaviour
{
    //Up at the top with your variables:
    private Vector3 dir = Vector3.up;
    private float speed = 1.5f;
    public float bounds1;
    public float bounds2;
    //Your Update function
    void Update()
    {
        transform.Translate(dir * speed * Time.deltaTime);
        {
            if (transform.position.x <= bounds1)
            {
                dir = Vector3.down;
            }
            else if (transform.position.x >= bounds2)
            {
                dir = Vector3.up;
            }
        }
    }
}
