using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    int levelUnlocked;
    public Button[] levelButtons;
    public GameObject levelsScreen;
    public GameObject mainMenuScreen;
    void Start()
    {
        levelUnlocked = PlayerPrefs.GetInt("levelUnlocked", 1);
        for(int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = false;
        }
        for (int i = 0; i < levelUnlocked; i++)
        {
            levelButtons[i].interactable = true;
        }
    }
    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
    public void LoadLastLevel()
    {
        SceneManager.LoadScene(levelUnlocked);
    }
    public void GoToLevelSelector()
    {
        mainMenuScreen.gameObject.SetActive(false);
        levelsScreen.gameObject.SetActive(true);
    }
    public void GoToMainMenu()
    {
        mainMenuScreen.gameObject.SetActive(true);
        levelsScreen.gameObject.SetActive(false);
    }
}
