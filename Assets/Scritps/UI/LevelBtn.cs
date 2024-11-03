using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelBtn : MonoBehaviour
{
    public int levelGoto;
    public bool isUnlocked;
    public GameObject levelState;
    public Image icon;
    public Text levelText;
    public Sprite checkMark;
    public Sprite lockIcon;
    Button m_btnComp;
    private void Start() {
        if(levelText){
            levelText.text = (levelGoto + 1).ToString("00");
        }

        m_btnComp = GetComponent<Button>();

        if(m_btnComp){
            m_btnComp.onClick.AddListener(() => GotoLevel());
        }

        if(!Prefs.IsGameEntered()){
            Prefs.SetLevelUnlocked(levelGoto, isUnlocked);
        }

        if(Prefs.IsLevelUnlocked(levelGoto)){
            if(levelState){
                levelState.SetActive(false);
            }

            if(Prefs.IsLevelPassed(levelGoto)){
                if(levelState){
                    levelState.SetActive(true);
                }

                if(icon && checkMark){
                    icon.sprite = checkMark;
                }
            }
        }

        else{
            if(levelState){
                levelState.SetActive(true);
            }

            if(icon && lockIcon){
                icon.sprite = lockIcon;
            }
        }
    }

    public void GotoLevel(){
        if(Prefs.IsLevelUnlocked(levelGoto)){
            LevelsManager.Ins.CurLevel = levelGoto;
            SceneManager.LoadScene(SceneConsts.GAME_PLAY);
        }
    }
}
