using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour
{
    private int currentLevel;
    private Rigidbody2D winRb;
    public GameObject winScreen;
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
                PassLevel();
                WinScreen();
                Destroy(collision.gameObject);
            }
        }
    // Do zmiany przy finale!!! 
    public void WinScreen()
    {
        winScreen.gameObject.SetActive(true);
    }
    public void GoToNextLevel()
    {
        SceneManager.LoadScene(currentLevel + 1);
    }

}
