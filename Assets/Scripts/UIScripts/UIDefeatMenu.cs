using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDefeatMenu : MonoBehaviour
{

    [SerializeField] private Button MainMenuButton;
    [SerializeField] private Button RestartButton;
    [SerializeField] private SceneLoader.GameScene SceneToRestart;

    private void Start()
    {
        MainMenuButton.onClick.AddListener(() => {
            SceneLoader.LoadTargetScene(SceneLoader.GameScene.MainMenu);
        });

        RestartButton.onClick.AddListener(() => {
            SceneLoader.LoadTargetScene(SceneToRestart);
        });
    }
    public void DisplayDefeatMenu()
    {

    }

    public void DisplayVictoryMenu()
    {

    }


}
