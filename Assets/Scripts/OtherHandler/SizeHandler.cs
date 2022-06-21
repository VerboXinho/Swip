using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeHandler : MonoBehaviour
{
    public bool scaleDown = false;
    private LevelScript winScreen;
    private Rigidbody2D otherRb;
    private SpriteRenderer spriteRenderer;
    private Vector3 scaleChange;
    public float minimum = 0.0f;
    public float maximum = 1f;
    public float duration = 3.0f;
    private float startTime;

    void Start()
    {
        startTime = Time.time;
        winScreen = GameObject.Find("WinSquare").GetComponent<LevelScript>();
        otherRb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        scaleChange = new Vector3(0, -0.001f, 0);
    }

    void Update()
    { 
        float t = (Time.time - startTime) / duration;
        spriteRenderer.color = new Color(1f, 1f, 1f, Mathf.SmoothStep(minimum, maximum, t));
        if (winScreen.IsWinScreen)
        {
            StartCoroutine(ScaleRoutine());

            if(scaleDown)
            {
                otherRb.transform.localScale += scaleChange;
            }
        }
        if (otherRb.transform.localScale.y < 0.001)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator ScaleRoutine()
    {
        yield return new WaitForSeconds(1);
        scaleDown = true;
    }
}
