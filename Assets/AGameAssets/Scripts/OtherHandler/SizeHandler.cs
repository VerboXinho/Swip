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
    public float minimum = 0.1f;
    public float maximum = 1f;
    public float duration = 2.0f;
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
        // Color and fade in handler for certain objects
        float t = (Time.time - startTime) / duration;
        if (gameObject.tag == "Obsc") 

            spriteRenderer.color = new Color(0.88f, 0.26f, 0.26f, Mathf.SmoothStep(minimum, maximum, t));

        else  if (gameObject.tag == "Break")

            spriteRenderer.color = new Color(0.44f, 0.44f, 0.44f, Mathf.SmoothStep(minimum, maximum, t));

        else 

            spriteRenderer.color = new Color(255 / 255, 255 / 255, 255 / 255, Mathf.SmoothStep(minimum, maximum, t));

        // Scale handler 
        if (winScreen.IsWinScreen)
        {
            StartCoroutine(ScaleRoutine());
            if(scaleDown) otherRb.transform.localScale += scaleChange;
        }
        if (otherRb.transform.localScale.y < 0.001) Destroy(gameObject);
    }
    // Routine for scaling down objects after win
    IEnumerator ScaleRoutine()
    {
        yield return new WaitForSeconds(1);
        scaleDown = true;
    }
}
