using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyWinFeedback : MonoBehaviour
{
    public static DontDestroyWinFeedback instance;
    
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
