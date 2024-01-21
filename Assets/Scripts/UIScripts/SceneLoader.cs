using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public static class SceneLoader 
{
    private static GameScene _targetScene;
    public enum GameScene { 
    
        MainMenu,
        Loading,
        Game,

    }

    public static void LoadTargetScene(GameScene scene) {

        _targetScene = scene;
        SceneManager.LoadScene(GameScene.Loading.ToString());

    }

    public static void LoadCallBack() {

        SceneManager.LoadScene(_targetScene.ToString());
    }
    
}
