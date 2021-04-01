using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    int enemiesEscaped;
    int enemiesDefeated;
    //add a enemies register to determine points gained
    public void AddEnemiesEscaped()
    {
        enemiesEscaped++;
    }
    public void AddEnemiesDefeated()
    {
        enemiesDefeated++;
    }
}
