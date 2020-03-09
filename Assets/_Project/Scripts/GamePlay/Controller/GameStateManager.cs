using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager instance;
    private void Awake()
    {
        instance = this;
    }

    public enum GameState {

        intro,countDown,GamePlay,Result
    }
    public GameState currentState;

    public int TotalTime = 90;
    private int minute;
    private int second;
    [SerializeField] Text timeText;
    [SerializeField] GameObject winPanel, loosePanel;
    private void Start()
    {
        Invoke("OnGameIntroState",.5f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            loadMenuScene();
        }
    }
    public void OnGameIntroState() {
        currentState = GameState.intro;
        // instruction appear
        UI_AnimationController.instance.AppearInstruction();
        // invokeCountDown after 10 sec
        Invoke("OnGameCountDownState", 10);
    }
    public void OnGameCountDownState()
    {
        currentState = GameState.countDown;
        // start countdown
        UI_AnimationController.instance.AppearCountDown();
        // invokeGamePlay after 4.5 sec
        Invoke("OnGameOnGamePlayState", 4.5f);
    }
    public void OnGameOnGamePlayState()
    {
        currentState = GameState.GamePlay;
        //start game
        ObjectThrower.instance.StartLaucngObjects();
        UI_AnimationController.instance.AppearInGameUI();

        // timer

        InvokeRepeating("Timer", 1,1);
     
       
    }
    public void OnGameResultState()
    {
        currentState = GameState.Result;
        // stop timer
        CancelInvoke("Timer");
        // stop spawn 
        ObjectThrower.instance.StopObjectThrow();

        // show result after one min;
        ShowResult();
        UI_AnimationController.instance.AppearResult();
        Invoke("loadMenuScene",10);
    }

    // helper functions

    private void Timer() {
        if (TotalTime > 0)
        {
            TotalTime--;
            minute = TotalTime / 60;
            second = TotalTime - minute * 60;
            if (second < 10)
            {
                timeText.text = minute.ToString() + ":0" + second.ToString();
            }
            else
                timeText.text = minute.ToString() + ":" + second.ToString();
        }
        else
        {
            //stop game show result
            OnGameResultState();
          //  CancelInvoke("ReverseCountdown_IR");
        }
    }

    private void ShowResult() {

        if (UI_Controller.instance.isWin) {
            winPanel.SetActive(true);
        }
        else {
            loosePanel.SetActive(true);
        }
    }

    private void loadMenuScene() {
        SceneManager.LoadScene("MainMenu");
    }
}
