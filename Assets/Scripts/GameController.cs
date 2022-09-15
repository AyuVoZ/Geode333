using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject EnemyManager;
    public bool Victory;

    private void Update()
    {
        if(Victory && GameObject.FindGameObjectsWithTag("enemy").Length == 0 && EnemyManager.GetComponent<EnemyManager>().finishedSpawning)
        {
            SceneManager.LoadScene("Victory");
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Scene Le Mouel");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
