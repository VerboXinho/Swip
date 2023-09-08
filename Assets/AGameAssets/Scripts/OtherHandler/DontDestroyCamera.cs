using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyCamera : MonoBehaviour
{
    public static DontDestroyCamera instance;
    
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if(instance == null)
        {
            instance = this;
        }
        else{
            Destroy(gameObject);
            return;
        }
    }
}
