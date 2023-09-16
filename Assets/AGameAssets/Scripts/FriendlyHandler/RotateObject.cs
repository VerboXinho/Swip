using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float lerpSpeed;
    private float timePassed;
    public Vector3[] rotationAngles;
    [SerializeField]int rotationAngle;
    private int rotationCount;
    float time;
   [SerializeField] bool isRotated = false;

    public void Start()
    {
        rotationCount = rotationAngles.Length;
    }
    void Update()
    {
        //Rotate Logic 
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(rotationAngles[rotationAngle]), Time.deltaTime * lerpSpeed);
        time = Mathf.Lerp(time, 2f, Time.deltaTime * lerpSpeed);
        if(time > 1.9f && isRotated)
        {
            time = 0;
            rotationAngle++;
            isRotated = false;
        }
        if(time > 1.9f  && !isRotated)
        {
             time = 0;
            rotationAngle++;
            isRotated = true;
        }
        if(rotationAngle > 4)
        {
            rotationAngle = 0;
        }
    }
}      
