using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyFailFeedback : MonoBehaviour
{
    public static DontDestroyFailFeedback instance;
    
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
