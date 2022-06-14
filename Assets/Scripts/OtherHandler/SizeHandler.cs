using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeHandler : MonoBehaviour
{
    private LevelScript winScreen;
    private Rigidbody2D otherRb;
    private Vector3 scaleChange;

    void Start()
    {
        winScreen = GameObject.Find("WinSquare").GetComponent<LevelScript>();
        otherRb = GetComponent<Rigidbody2D>();
        scaleChange = new Vector3(-0.001f, -0.001f, -0.001f);
    }

    void Update()
    {
        if (winScreen.IsWinScreen)
        {
            otherRb.transform.localScale += scaleChange;
        }
        if (otherRb.transform.localScale.x < 0.001)
        {
            Destroy(gameObject);
        }
    }
}
