using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseHandler : MonoBehaviour
{
    GameObject pausePanel;
    PlayerController playerMain;
    void Start()
    {
        playerMain = GameObject.Find("MainPlayer").GetComponent<PlayerController>();
        pausePanel = GameObject.Find("PausePanel");
        pausePanel.gameObject.SetActive(false);
    }
    public void Pause()
    {
        playerMain.isPause = true;
        pausePanel.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
