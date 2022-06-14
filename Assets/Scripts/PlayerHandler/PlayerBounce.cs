using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerBounce : MonoBehaviour
{
    public bool IsWinScreen = false;
    private Rigidbody2D bounceRb;
    private int currentLevelmm;
    public TextMeshProUGUI bounceText;
    private int bounceScore;
    Vector3 lastVelocity;
    private void Start()
    {
        currentLevelmm = SceneManager.GetActiveScene().buildIndex;
        if(currentLevelmm==0)
        {
            bounceRb.AddForce(transform.up * 5, ForceMode2D.Impulse);
            bounceRb.AddForce(transform.right * 5, ForceMode2D.Impulse);
        }
    }
    private void Awake()
    {
        bounceScore = 0;
        bounceRb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        lastVelocity = bounceRb.velocity;
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Bounds"))
        { 
            SceneManager.LoadScene(currentLevelmm);
        }
        bounceScore++;
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, coll.contacts[0].normal );
        bounceRb.velocity = direction * Mathf.Max(speed, 0f);
        bounceText.text = "Bounces: " + bounceScore;
    }
}
