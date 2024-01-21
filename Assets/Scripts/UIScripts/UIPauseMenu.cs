using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIPause_Menu : MonoBehaviour
{
    [SerializeField] private Button MainMenuButton;
    [SerializeField] private Button ResumeButton;

    private void Start()
    {
        MainMenuButton.onClick.AddListener(() => {
            SceneLoader.LoadTargetScene(SceneLoader.GameScene.MainMenu);
        });

        ResumeButton.onClick.AddListener(() => {
            GameManager.instance.ToggleGameState();
        });
    }





}
