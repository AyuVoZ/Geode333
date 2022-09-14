using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    public int Health;

    void OnEnable()
    {
        EnemyController.onHitCastle += LooseHp;
    }

    void LooseHp()
    {
        Health -= 1;
    }
}
