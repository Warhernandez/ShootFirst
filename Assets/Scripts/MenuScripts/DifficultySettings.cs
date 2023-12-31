﻿using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DifficultySettings : MonoBehaviour
{

    void Start()
    {
        PlayerPrefs.SetString("Difficulty", "Medium");
    }

    public void SetDifficulty(string difficulty)
    {
        //I've never used playerprefs before so if i mess this up.......... oops!
        // Save the selected difficulty to PlayerPrefs.
        PlayerPrefs.SetString("Difficulty", difficulty);
        PlayerPrefs.Save(); // Save PlayerPrefs immediately.
    }

    public string GetDifficulty()
    {
        // Retrieve the selected difficulty from PlayerPrefs. If not set, default to "Normal."
        return PlayerPrefs.GetString("Difficulty", "Normal");
    }
}
