using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingLineHandler : MonoBehaviour
{
    //Up at the top with your variables:
    private Vector3 dir = Vector3.left;
    private int speed = 1;
    //Your Update function
    void Update()
    {
        transform.Translate(dir * speed * Time.deltaTime);

        if (transform.position.x <= -2)
        {
            dir = Vector3.right;
        }
        else if (transform.position.x >= 2)
        {
            dir = Vector3.left;
        }
    }
}
