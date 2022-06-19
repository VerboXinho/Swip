using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerSavedDataDelete : MonoBehaviour
{

    public void Restart()
    {
        PlayerPrefs.DeleteAll();
    }

}
