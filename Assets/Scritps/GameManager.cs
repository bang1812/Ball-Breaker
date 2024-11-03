using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int timeDelay;
    int m_curTimeDelay;
    public Ball ball;
    int m_level;
    int m_score;
    BricksManager m_levelObj;

    public int Level { get => m_level; }
    public BricksManager LevelObj { get => m_levelObj; }

    public override void Awake()
    {
        MakeSingleton(false);
    }

    public override void Start()
    {
        m_curTimeDelay = timeDelay;

        StartCoroutine(CountingDown());

        Prefs.hasNewBest = false;

        GameGUIManager.Ins.UpdateScore(m_score);
        
        AudioController.Ins.PlayBackgroundMusic();
    }

    IEnumerator CountingDown(){
        BricksManager[] levelPrefabs = LevelsManager.Ins.levelPrefebs;

        if(levelPrefabs != null && levelPrefabs.Length > 0 && levelPrefabs.Length > LevelsManager.Ins.CurLevel){
            BricksManager levelPrefab = levelPrefabs[LevelsManager.Ins.CurLevel];

            if(levelPrefab){
                m_level = LevelsManager.Ins.CurLevel;
                m_levelObj = Instantiate(levelPrefab, Vector3.zero, Quaternion.identity);
            }
        }

        while(m_curTimeDelay > 0){
            yield return new WaitForSeconds(1);
            m_curTimeDelay--;

            if(m_curTimeDelay > 0){
                AudioController.Ins.PlaySound(AudioController.Ins.timeBeep);
            }
            else{
                AudioController.Ins.PlaySound(AudioController.Ins.ballStartTrigger);
            }

            GameGUIManager.Ins.UpdateTimeCounDown(m_curTimeDelay);
        }

        if(ball != null){
            ball.Trigger();
        }

        Prefs.SetGameEntered(true);
    }

    public void AddScore(int scoreToAdd){
        m_score += scoreToAdd;
        Prefs.bestScore = m_score;

        GameGUIManager.Ins.UpdateScore(m_score);
    }

    public int YourBest(){
        return m_score;
    }
}
