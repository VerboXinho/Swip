using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableHandler : MonoBehaviour
{
    private Rigidbody2D breakRb;
    private void Start()
    {
        breakRb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(breakRb.gameObject);
        }
    }
}
