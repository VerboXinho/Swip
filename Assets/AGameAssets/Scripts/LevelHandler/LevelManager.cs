using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public float minimum = 0.0f;
    public float maximum = 1f;
    public float duration = 2.0f;
    private float startTime;
    public int levelUnlocked;
    [SerializeField] bool isLevelLoading = false;
    public Button[] levelButtons;
    public GameObject levelsScreen;
    public GameObject mainMenuScreen;
    public SpriteRenderer menuPlayersprite;
    public SpriteRenderer menuBoundssprite1;
    public SpriteRenderer menuBoundssprite2;
    public SpriteRenderer menuBoundssprite3;
    public SpriteRenderer menuBoundssprite4;
    public TextMeshProUGUI textMenu;
    public TextMeshProUGUI textMenuButtonPlay;
    public TextMeshProUGUI textMenuButtonLevels;
    void Start()
    {
        startTime = Time.time;
        levelUnlocked = PlayerPrefs.GetInt("levelUnlocked", 1);
        Debug.Log(levelUnlocked);
        for(int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = false;
        }
        for (int i = 0; i < levelUnlocked; i++) //Add <= when level 45 is fixed
        {
                levelButtons[i].interactable = true;
        }
    }
    private void Update()
    {
        float t = (Time.time - startTime) / duration;
        if (isLevelLoading)
        {
            menuPlayersprite.color = new Color(1f, 1f, 1f, Mathf.SmoothStep(maximum, minimum, t));
            menuBoundssprite1.color = new Color(1f, 1f, 1f, Mathf.SmoothStep(maximum, minimum, t));
            menuBoundssprite2.color = new Color(1f, 1f, 1f, Mathf.SmoothStep(maximum, minimum, t));
            menuBoundssprite3.color = new Color(1f, 1f, 1f, Mathf.SmoothStep(maximum, minimum, t));
            menuBoundssprite4.color = new Color(1f, 1f, 1f, Mathf.SmoothStep(maximum, minimum, t));
            textMenu.CrossFadeAlpha(0.0f, 0.5f, false);
            textMenuButtonPlay.CrossFadeAlpha(0.0f, 0.5f, false);
            textMenuButtonLevels.CrossFadeAlpha(0.0f, 0.5f, false);
        }
    }
    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
        isLevelLoading = true;
    }
    public void LoadLastLevel()
    {
        StartCoroutine(LoadLevelRoutine());
        isLevelLoading = true;
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
    IEnumerator LoadLevelRoutine()
    {
        yield return new WaitForSeconds(3);
        if(levelUnlocked == 46)
        {
            SceneManager.LoadScene(45);
        }
        else
        {
            SceneManager.LoadScene(levelUnlocked);
        }
    }
}
