using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject ConfirmationPanel;
    public GameObject LevelSelectPanel;
    public int StartGameSceneIndex;
    private void Start()
    {
        ConfirmationPanel.SetActive(false);
    }
    //Buttons
    public void StartGame()
    {
        SceneManager.LoadScene(StartGameSceneIndex);
    }
    public void ExitGame()
    {
        ConfirmationPanel.SetActive(true);
    }
    public void ContinueGame()
    {

    }
    public void SelectLevel()
    {
        LevelSelectPanel.SetActive(true);
    }
    public void Options()
    {

    }
    //Panel Transitions
    public void Comfirmation(bool isYes)
    {
        if (isYes)
        {
            Application.Quit();
            Debug.Log("Game Quit");
        }
        if (!isYes)
        {
            ConfirmationPanel.SetActive(false);
        }
    }
}
