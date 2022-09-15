using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Base : MonoBehaviour
{
    public int Health;

    private void Update()
    {
        if(Health <= 0)
        {
            SceneManager.LoadScene("Game Over");
        }
    }

    void OnEnable()
    {
        EnemyController.onHitCastle += LooseHp;
    }

    void LooseHp()
    {
        Health -= 1;
    }
}
