using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using MoreMountains.Feedbacks;

public class LevelScript : MonoBehaviour
{
    public bool IsWinScreen = false;
    private int currentLevel;
    private Rigidbody2D winRb;
    public GameObject winScreen;
    public ParticleSystem winParticle;
    MMFeedbacks winFeedback;

    private void Start() 
    {
         winRb = GetComponent<Rigidbody2D>();
         winFeedback = GameObject.Find("WinFeedBack").GetComponent<MMF_Player>();
    }
    
    public void PassLevel()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;

        if (currentLevel >= PlayerPrefs.GetInt("levelUnlocked"))
        {
            PlayerPrefs.SetInt("levelUnlocked", currentLevel + 1);
        }


        Debug.Log("LEVEL" + PlayerPrefs.GetInt("levelUnlocked") + "UNLOCKED");
    }
    private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                FindObjectOfType<AudioManager>().Play("Win");
                winFeedback.PlayFeedbacks();
                collision.gameObject.SetActive(false);
                IsWinScreen = true;
                PassLevel();
                WinScreen();
                winParticle.Play();
            }
            if (collision.gameObject.CompareTag("tPlayer"))
            {
                SceneManager.LoadScene(2);
                collision.gameObject.SetActive(false);
            }
    }
    // Do zmiany przy finale!!! 
    public void WinScreen() => StartCoroutine(WinScreenRoutine());
    IEnumerator WinScreenRoutine()
    {
        yield return new WaitForSeconds(2);
        winScreen.gameObject.SetActive(true);
    }
    public void GoToNextLevel() => SceneManager.LoadScene(currentLevel + 1);
    
}
