using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // P�epne "Scenu" na dal��.
    // V tomhle p��pad� jen zvedne index o 1.
    // MainMenu je 0, Hra je 1.
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Vypne aplikaci
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Aplikace by se m�la vypnout!");
    }
}
