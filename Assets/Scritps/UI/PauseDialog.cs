using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseDialog : Dialog
{
    public Text bestScoreText;

    public override void Show(bool isShow)
    {
        Time.timeScale = 0;

        base.Show(isShow);

        if(Prefs.hasNewBest){
            if(bestScoreText){
                bestScoreText.text = "NEW BEST : " + Prefs.bestScore.ToString("n0");
            }
        }
        else{
            if(bestScoreText){
                bestScoreText.text = "BEST SCORE : " + Prefs.bestScore.ToString("n0");
            }
        }
    }

    public void HomeBtn(){
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneConsts.MAIN);
    }

    public void ResumeBtn(){
        Time.timeScale = 1;
        Close();
    }

    public void ReplayBtn(){
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneConsts.GAME_PLAY);
    }
}
