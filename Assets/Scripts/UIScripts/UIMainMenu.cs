using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private Button StartButton;
    [SerializeField] private Button EndButton;
 

    private void Start()
    {
        StartButton.onClick.AddListener(() => {
            SceneLoader.LoadTargetScene(SceneLoader.GameScene.Game);
        });

        EndButton.onClick.AddListener(() => {
            Application.Quit();
        });
    }
}
