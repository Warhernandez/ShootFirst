using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    public void Scene1()
    {
        SceneManager.LoadScene(1);
    }
    public void Scene2()
    {
        SceneManager.LoadScene(2);
    }
    public void Scene3()
    {
        SceneManager.LoadScene(3);
    }
    public void Scene4()
    {
        SceneManager.LoadScene(4);
    }
    public void RapidInstructions()
    {
        SceneManager.LoadScene(5);
    }
    public void SharpInstructions()
    {
        SceneManager.LoadScene(6);
    }
    public void WantedInstructions()
    {
        SceneManager.LoadScene(7);
    }
}