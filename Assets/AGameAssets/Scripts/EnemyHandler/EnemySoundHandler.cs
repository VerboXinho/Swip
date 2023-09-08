using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySoundHandler : MonoBehaviour
{
    public AudioClip deathClip;
    public AudioSource deathSoundSource;
    private Rigidbody2D enemyRb;
    public ParticleSystem deathParticle;
    MMFeedbacks failFeedback;
    private int currentLevel;
    public bool isDestroying = false;

    void Start() 
    {
        failFeedback = GameObject.Find("FailFeedBack").GetComponent<MMF_Player>();
        enemyRb = GetComponent<Rigidbody2D>();

    }
    private void Update() => currentLevel = SceneManager.GetActiveScene().buildIndex;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            failFeedback.PlayFeedbacks();
            FindObjectOfType<AudioManager>().Play("Death");
            Destroy(collision.gameObject);
            deathParticle.Play();
            StartCoroutine(WaitForRestart());
        }
    }
    IEnumerator WaitForRestart()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(currentLevel);
    }
}
