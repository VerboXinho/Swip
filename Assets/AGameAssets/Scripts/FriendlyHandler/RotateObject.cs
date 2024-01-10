using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    Quaternion targetRotation;
    float rotationSpeed = 45f;
    [SerializeField]float rotationTime;
    [SerializeField]float pauseTime;
    float lastRotationTime;


    public void Start()
    {
        //Get target rotation, by Z axis rotate 45 degress
        targetRotation = transform.rotation * Quaternion.Euler(0,0,45);
    }
    void Update()
    {
        if(lastRotationTime < pauseTime)
        {
            lastRotationTime += Time.deltaTime;
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation,targetRotation, rotationSpeed * Time.deltaTime/rotationTime);

            //Snap to the angle
            if (Quaternion.Angle(transform.rotation, targetRotation) < 1.0f)
            {
                transform.rotation = targetRotation;
                // Update target rotation for the next rotation
                targetRotation *= Quaternion.Euler(0, 0, 45);
                lastRotationTime = 0f;
            }
        }
    }
}      
