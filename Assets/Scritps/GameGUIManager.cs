using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameGUIManager : Singleton<GameGUIManager>
{
    public Text scoreText;
    public Text timeCoutingDownText;

    public PauseDialog pauseDialog;
    public WinDialog winDialog;
    public GameOverDialog gameOverDialog;

    public override void Awake()
    {
        MakeSingleton(false);
    }

    public void UpdateScore(int score){
        if(scoreText){
            scoreText.text = "SCORE : " + score.ToString("n0");
        }
    }

    public void UpdateTimeCounDown(int time){
        if(timeCoutingDownText){
            timeCoutingDownText.text = time.ToString("00");
        }

        if(time <= 0){
            if(timeCoutingDownText){
                timeCoutingDownText.gameObject.SetActive(false);
            }
        }
    }

    public void BackToHomeBtn(){
        SceneManager.LoadScene(SceneConsts.MAIN);
    }

    public void PauseGame(){
        if(pauseDialog){
            pauseDialog.Show(true);
        }
    }
}
