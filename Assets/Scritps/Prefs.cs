using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Prefs
{
    public static bool hasNewBest;
    
    public static void SetBool(bool isTrue, string key){
        if(isTrue){
            PlayerPrefs.SetInt(key, 1);
        }
        else{
            PlayerPrefs.SetInt(key, 0);
        }
    }

    public static bool GetBool(string key){
        return PlayerPrefs.GetInt(key) == 1 ? true : false;
    }

    public static int bestScore{
        set{
            if(PlayerPrefs.GetInt(PrefConsts.BEST_SCORE, 0)< value){
                hasNewBest = true;
                PlayerPrefs.SetInt(PrefConsts.BEST_SCORE, value);
            }
            else{
                hasNewBest = false;
            }
        }

        get => PlayerPrefs.GetInt(PrefConsts.BEST_SCORE, 0);
    }

    public static bool IsLevelUnlocked(int level){
        return GetBool(PrefConsts.LEVEL_UNLOCKED + level);
    }

    public static bool IsLevelPassed(int level){
        return GetBool(PrefConsts.LEVEL_PASSED + level);
    }

    public static void SetLevelUnlocked(int level, bool unlocked){
        SetBool(unlocked, PrefConsts.LEVEL_UNLOCKED + level);
    }

    public static void SetLevelPassed(int level, bool passed){
        SetBool(passed, PrefConsts.LEVEL_PASSED + level);
    }

    public static bool IsGameEntered(){
        return GetBool(PrefConsts.IS_GAME_ENTERED);
    }

    public static void SetGameEntered(bool isEntered){
        SetBool(isEntered, PrefConsts.IS_GAME_ENTERED);
    }
}
