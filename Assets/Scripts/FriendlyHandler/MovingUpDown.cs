using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingUpDown : MonoBehaviour
{
    //Up at the top with your variables:
    private Vector3 dir = Vector3.up;
    private int speed = 1;
    public float bounds1;
    public float bounds2;
    //Your Update function
    void Update()
    {
        transform.Translate(dir * speed * Time.deltaTime);
        {
            if (transform.position.y <= bounds1)
            {
                dir = Vector3.up;
            }
            else if (transform.position.y >= bounds2)
            {
                dir = Vector3.down;
            }
        }
    }
}
