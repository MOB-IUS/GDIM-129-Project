using UnityEngine;
using System;
using System.IO;

public class SaveFile
{
    private string m_Filename, m_Extension;
    public string Filename { get { return m_Filename; } }
    public string Extension { get { return m_Extension; } }

    private string m_SavePath;
    public string SavePath { get { return m_SavePath; } }

    public SaveFile(string filename, bool encrypt = false)
    {
        m_Filename = filename;

        if (encrypt) m_Extension = ".dat";
        else m_Extension = ".json";

        m_SavePath = Path.Combine(Application.persistentDataPath, m_Filename + m_Extension);
    }

    public void Save() 
    {
        
    }

    public SaveData Load() 
    {
        SaveData emptyData = SaveBuilder.BuildEmptySave();
        string json = ReadSave();
        JsonUtility.FromJsonOverwrite(json, emptyData);
        return emptyData;
    }

    private string ReadSave() { return ""; }
    private void WriteSave(string json) { }
    
}
