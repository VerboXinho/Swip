using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerBounce : MonoBehaviour
{
    private Rigidbody2D bounceRb;
    public TextMeshProUGUI bounceText;
    private int bounceScore;
    Vector3 lastVelocity;
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
        bounceScore++;
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, coll.contacts[0].normal );
        bounceRb.velocity = direction * Mathf.Max(speed, 0f);
        bounceText.text = "Bounces: " + bounceScore;
    }
}
