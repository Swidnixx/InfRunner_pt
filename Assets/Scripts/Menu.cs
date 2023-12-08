using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("MainScene");
    }

    public GameObject menuPanel, shopPanel;
    public void GoToShop()
    {
        menuPanel.SetActive(false);
        shopPanel.SetActive(true);
    }
    public void GoToMenu()
    {
        menuPanel.SetActive(true);
        shopPanel.SetActive(false);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
