using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelScript : MonoBehaviour
{
    public bool IsWinScreen = false;
    private int currentLevel;
    private Rigidbody2D winRb;
    public GameObject winScreen;
    public ParticleSystem winParticle;
    private void Start()
    {
        winRb = GetComponent<Rigidbody2D>();
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
    private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                IsWinScreen = true;
                PassLevel();
                WinScreen();
                Destroy(collision.gameObject);
                winParticle.Play();
            }
            if (collision.gameObject.CompareTag("tPlayer"))
            {
                SceneManager.LoadScene(2);
                Destroy(collision.gameObject);
            }
    }
    // Do zmiany przy finale!!! 
    public void WinScreen()
    {
        StartCoroutine(WinScreenRoutine());
    }
    IEnumerator WinScreenRoutine()
    {
        yield return new WaitForSeconds(2);
        winScreen.gameObject.SetActive(true);
    }
    public void GoToNextLevel()
    {
        SceneManager.LoadScene(currentLevel + 1);
    }

}
