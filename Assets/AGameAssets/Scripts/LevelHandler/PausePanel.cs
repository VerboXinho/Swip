using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    PlayerController playerMain;
    void Start()
    {
        playerMain = GameObject.Find("MainPlayer").GetComponent<PlayerController>();
    }
    public void Resume()
    {
        playerMain.StartCoroutine(playerMain.PauseCooldown());
        transform.parent.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
