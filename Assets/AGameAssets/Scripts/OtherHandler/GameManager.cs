using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float minimum = 0.0f;
    public float maximum = 1f;
    public float duration = 2.0f;
    private float startTime;
    public SpriteRenderer sprite;

    void Start() => startTime = Time.time;

    // Update is called once per frame

}
