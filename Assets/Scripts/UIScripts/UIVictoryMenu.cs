using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIVictoryMenu : MonoBehaviour
{
    [SerializeField] private Button StartButton;


    private void Start()
    {
        StartButton.onClick.AddListener(() => {
            SceneLoader.LoadTargetScene(SceneLoader.GameScene.MainMenu);
        });
    }
}
