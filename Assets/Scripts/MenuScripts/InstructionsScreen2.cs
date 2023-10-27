using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InstructionsScreen2 : MonoBehaviour
{
    //setup.........
    public TMP_Text Inscructions1;
    public float Delay1 = 1.0f;
    public TMP_Text Inscructions2;
    public float Delay2 = 2.0f;
    public TMP_Text Inscructions3;
    public float Delay3 = 3.0f;
    private int ammo;
    private int time;
    // Start is called before the first frame update
    void Start()
    {
        string selectedDifficulty = PlayerPrefs.GetString("Difficulty", "Normal");

        // Adjust game parameters based on difficulty.
        if (selectedDifficulty == "Easy")
        {
            // Set easy difficulty parameters.
            ammo = -1; //infinite ammo
            time = 10;
        }
        else if (selectedDifficulty == "Medium")
        {
            // Set medium difficulty parameters.
            ammo = 5;
            time = 7;
        }
        else if (selectedDifficulty == "Hard")
        {

            ammo = 3;
            time = 5;
        }

        //Hide text at start 
        Inscructions1.enabled = false;
        Inscructions2.enabled = false;
        Inscructions3.enabled = false;
        //display text after a delay (Bishi Bashi Style)
        Invoke("DisplayText1", Delay1);
        Invoke("DisplayText2", Delay2);
        Invoke("DisplayText3", Delay3);
    }

    void DisplayText1()
    {
        Inscructions1.enabled = true;
    }
    void DisplayText2()
    {
        Inscructions2.text = "Time: " + time.ToString("F1") + " Seconds";
        Inscructions2.enabled = true;

    }
    void DisplayText3()
    {
        if (ammo == -1)
        {
            Inscructions3.text = "Ammo: ∞ Bullets";

        }
        else
        {
            Inscructions3.text = "Ammo: " + ammo.ToString() + " Bullets";
        }

        Inscructions3.enabled = true;
    }
}
