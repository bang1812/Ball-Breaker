using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsManager : Singleton<LevelsManager>
{
    public BricksManager[] levelPrefebs;
    int m_curLevel;

    public int CurLevel { get => m_curLevel; set => m_curLevel = value; }
}
