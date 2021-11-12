using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TownExit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Stage_Town_1")|| SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Stage_Town_Respawn"))
            {
                SceneManager.LoadScene("EntFor1", LoadSceneMode.Single);
            }
        }
    }
}
