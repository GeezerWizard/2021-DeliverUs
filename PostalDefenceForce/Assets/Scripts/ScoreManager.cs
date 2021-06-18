using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // Refactor enemy references with packages
    float totalEnemies;
    int enemiesEscaped;
    int enemiesDefeated;
    int[] levels;//how to connect this with the player selected level
    int currentLevel;
    public GameObject scoreScreen;
    public Text escapedText;
    public Text defeatedText;
    public Text finalScoreText;

    private void Start()
    {
        scoreScreen.SetActive(false);
    }
    public void AddEnemiesEscaped()
    {
        enemiesEscaped++;
        if (enemiesEscaped + enemiesDefeated == totalEnemies)
        {
            StartCoroutine(ShowScoreScreen());
        }
    }
    public void AddEnemiesDefeated()
    {
        enemiesDefeated++;
        if (enemiesDefeated + enemiesEscaped == totalEnemies)
        {
            StartCoroutine(ShowScoreScreen());
        }
    }
    public void AddToTotalEnemies(int amount)
    {
        totalEnemies += amount;
    }
    public void SaveScore(int scoreAmount, int currentLevel)
    {
        PlayerPrefs.SetInt("score", scoreAmount);//find out if you can have a custom player prefs key or array
        //Save score to player prefs
    }
    IEnumerator ShowScoreScreen()
    {
        yield return new WaitForSeconds(1);
        escapedText.text = enemiesEscaped.ToString();
        defeatedText.text = enemiesDefeated.ToString();
        finalScoreText.text = (enemiesDefeated/totalEnemies * 100).ToString() + "%";
        scoreScreen.SetActive(true);
    }

    public void ResetScore()
    {
        totalEnemies = 0;
        enemiesEscaped = 0;
        enemiesDefeated = 0;
    }
}
