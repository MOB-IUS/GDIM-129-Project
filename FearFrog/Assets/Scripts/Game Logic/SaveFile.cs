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

    private DateTime m_LastUpdated;
    public DateTime LastUpdated { get { return m_LastUpdated; } }

    public SaveFile(string filename, bool encrypt = false)
    {
        m_Filename = filename;

        if (encrypt) m_Extension = ".dat";
        else m_Extension = ".json";

        m_SavePath = Path.Combine(Application.persistentDataPath, m_Filename + m_Extension);
    }
    
}
