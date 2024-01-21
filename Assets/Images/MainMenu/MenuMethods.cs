using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMethods : MonoBehaviour
{
    [SerializeField] GameObject menuButtons;
    [SerializeField] GameObject[] images;


    public void LoadGameScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGameButton()
    {
        Application.Quit();
    }
}
