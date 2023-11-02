using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    public void Difficulty()
    {
        SceneManager.LoadScene(0);
    }
    public void Menu()
    {
        SceneManager.LoadScene(1);
    }
    public void Rapidfire()
    {
        SceneManager.LoadScene(2);
    }
    public void Sharpshooter()
    {
        SceneManager.LoadScene(3);
    }
    public void Wanted()
    {
        SceneManager.LoadScene(4);
    }
    public void About()
    {
        SceneManager.LoadScene(5);
    }
    public void RapidInstructions()
    {
        SceneManager.LoadScene(6);
    }
    public void SharpInstructions()
    {
        SceneManager.LoadScene(7);
    }
    public void WantedInstructions()
    {
        SceneManager.LoadScene(8);
    }
}