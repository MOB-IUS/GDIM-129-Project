using UnityEngine;
using System;

[System.Serializable]
public class SaveBuilder
{
    [SerializeField] private PlayerData m_Player;
    public PlayerData Player { get { return m_Player; } }
    [SerializeField] private GameData m_Game;
    public GameData Game { get { return m_Game; } }

    /*
    public static SaveData BuildSave()
    {
        return new SaveData(m_Player.DataClass);
    }
    */

    public static SaveData BuildEmptySave()
    {
        return new SaveData();
    }
}


public class SaveData
{
    private PlayerDataClass m_Player;
    public PlayerDataClass Player { get { return m_Player; } }

    private DateTime m_LastSaved;
    public DateTime LastSaved { get { return m_LastSaved; } }

    public SaveData(PlayerDataClass player)
    {
        m_Player = player;
        
        LogSave();
    }

    public SaveData() { LogSave(); }

    public void LogSave()
    {
        m_LastSaved = DateTime.UtcNow;
    }
}
