using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerChooser : MonoBehaviour
{
    [SerializeField] private TowerSO tower1;
    [SerializeField] private TowerSO tower2;
    [SerializeField] private TowerSO tower3;
    [SerializeField] private TowerSO tower4;
    [SerializeField] private TowerSO tower5;

    [SerializeField] private PlayerController player;
    private PlayerInputs playerInputs;
    

    private void Start()
    {
        playerInputs = PlayerInputs.Instance;
        playerInputs.button1Performed += PlayerInputs_button1Performed;
        playerInputs.button2Performed += PlayerInputs_button2Performed1;
        playerInputs.button3Performed += PlayerInputs_button3Performed;
        playerInputs.button4Performed += PlayerInputs_button4Performed;
        playerInputs.button5Performed += PlayerInputs_button5Performed;
    }

    private void PlayerInputs_button5Performed(object sender, System.EventArgs e)
    {
        player.TakeGameObject(tower5);
    }

    private void PlayerInputs_button4Performed(object sender, System.EventArgs e)
    {
        player.TakeGameObject(tower4);
    }

    private void PlayerInputs_button3Performed(object sender, System.EventArgs e)
    {
        player.TakeGameObject(tower3);
    }

    private void PlayerInputs_button2Performed1(object sender, System.EventArgs e)
    {
        player.TakeGameObject(tower2);
    }

    private void PlayerInputs_button1Performed(object sender, System.EventArgs e)
    {
        player.TakeGameObject(tower1);
    }
}
