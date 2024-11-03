using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinDialog : Dialog
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
                // bestScoreText.text = "BEST SCORE : " + Prefs.bestScore.ToString("n0");
                bestScoreText.text = "YOUR SCORE : " + GameManager.Ins.YourBest();
            }
        }

        AudioController.Ins.PlaySound(AudioController.Ins.win);
    }

    public void HomeBtn(){
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneConsts.MAIN);
    }

    public void ReplayBtn(){
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneConsts.GAME_PLAY);
    }

    public void ContinueBtn(){
        Time.timeScale = 1;
        LevelsManager.Ins.CurLevel++;
        SceneManager.LoadScene(SceneConsts.GAME_PLAY);
    }
}
