using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;
using System.Runtime.CompilerServices;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private PlayerInputs playerInputs;
    private void Awake()
    {
        instance = this;
    }

    [Header("Menus")]
    [SerializeField] private GameObject _PauseMenu;
    [SerializeField] private GameObject _greyScreen;
    [SerializeField] private GameObject _defeatMenu;
    [SerializeField] private GameObject _victoryMenu;

    [Header("MMFeedbacks")]
    [SerializeField] private MMFeedbacks _pauseGameTime;
    [SerializeField] private MMFeedbacks _resetGameTime;
    //[SerializeField] private MMFeedbacks _lowerMusicTrack;
    //[SerializeField] private MMFeedbacks _resetMusicTrack;
    //[SerializeField] private MMFeedbacks _FreeMusicTrack;
    //[SerializeField] private MMFeedbacks _MainMusic;
    [SerializeField] private MMFeedbacks freeAndWinMusic;
    [SerializeField] private MMFeedbacks defeat;
    [SerializeField] private MMFeedbacks vic;

    [Header("Other")]

    [SerializeField] private GameoverScript over;
    [SerializeField] private Wave wave;

    private bool gameOver = false;
    private bool gamePaused = false;

    private void Start()
    {
        PlayerInputs.Instance.escapePerformed += PlayerInputs_escapePerformed;
        over.GameOver += Over_GameOver;
        wave.GameWon += Wave_GameWon;
    }

    private void Wave_GameWon(object sender, System.EventArgs e)
    {
        StartCoroutine(GameWon());
    }

    private void PlayerInputs_escapePerformed(object sender, System.EventArgs e)
    {
        ToggleGameState();
    }

    private void Over_GameOver(object sender, System.EventArgs e)
    {
        StartCoroutine(PlayerDefeated());
    }

    private IEnumerator GameWon()
    {
        gameOver = true;
        vic.PlayFeedbacks();
        freeAndWinMusic.PlayFeedbacks();

        yield return new WaitForSeconds(1f);
        _pauseGameTime.PlayFeedbacks();
        gamePaused = true;
        _victoryMenu.SetActive(true);
        _greyScreen.SetActive(true);
    }

    private IEnumerator PlayerDefeated()
    {

        gameOver = true;
        defeat.PlayFeedbacks();

        yield return new WaitForSeconds(1f);
        //_FreeMusicTrack.PlayFeedbacks();
        _pauseGameTime.PlayFeedbacks();
        _defeatMenu.SetActive(true);
    }

    public void ToggleGameState()
    {

        if (gameOver) return;

        if (gamePaused)
        {
           // _resetMusicTrack.PlayFeedbacks();
            gamePaused = false;
            _PauseMenu.SetActive(false);
            _greyScreen.SetActive(false);
            _resetGameTime.PlayFeedbacks();


        }
        else if (!gamePaused)
        {
           // _lowerMusicTrack.PlayFeedbacks();
            gamePaused = true;
            _PauseMenu.SetActive(true);
            _greyScreen.SetActive(true);
            _pauseGameTime.PlayFeedbacks();
        }

    }

    private void OnDestroy()
    {
        over.GameOver -= Over_GameOver;
        wave.GameWon -= Wave_GameWon;
        PlayerInputs.Instance.escapePerformed -= PlayerInputs_escapePerformed;
    }

}
