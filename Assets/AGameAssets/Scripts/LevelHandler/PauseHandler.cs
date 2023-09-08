using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseHandler : MonoBehaviour
{
    public GameObject pausePanel;
    public void Pause()
    {
        pausePanel.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void UnPause()
    {
        pausePanel.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
