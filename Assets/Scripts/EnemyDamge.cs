using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamge : MonoBehaviour
{
    public EnemyInteligent enemy;

    public void damage()
    {
        enemy.hitPlayer();
    }
}
