using UnityEngine;
using UnityEngine.UI;

public class SavePrefs : MonoBehaviour
{
    string intKey;
    string floatKey;
    string stringKey;
    int intToSave;
    float floatToSave;
    string stringToSave;

    public void RaiseInteger()
    {
        intToSave++;
    }
    public void RaiseFloat()
    {
        floatToSave += 0.1f;
    }
    public void SaveGame()
    {
        PlayerPrefs.SetInt(intKey, intToSave);
        PlayerPrefs.SetFloat(floatKey, floatToSave);
        PlayerPrefs.SetString(stringKey, stringToSave);
        PlayerPrefs.Save();
        Debug.Log("Game Data Saved.");
    }
    public void LoadGame()
    {
        if (PlayerPrefs.HasKey(intKey))
        {
            intToSave = PlayerPrefs.GetInt(intKey);
            floatToSave = PlayerPrefs.GetFloat(floatKey);
            stringToSave = PlayerPrefs.GetString(stringKey);
            Debug.Log("Game Data Loaded.");
        }
        else
        {
            Debug.LogError("No Game Data to Load.");
        }
    }
    public void ResetGame()
    {
        PlayerPrefs.DeleteAll();
        intToSave = 0;
        floatToSave = 0.0f;
        stringToSave = "";
        Debug.Log("Data Reset Complete");
    }
}
