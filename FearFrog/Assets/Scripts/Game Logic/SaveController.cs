using UnityEngine;
using System.Collections.Generic;

public class SaveController : MonoBehaviour
{
    private const string m_SaveName = "save_";

    private SaveData m_CurrentSaveData;
    private SaveFile m_CurrentSaveFile;
    private List<SaveFile> m_Saves;

    [SerializeField] private SaveBuilder m_SaveBuilder;

    private void Start()
    {
        m_Saves = new List<SaveFile>();
    }

    private void SaveGame()
    {

    }

    private void LoadGame()
    {

    }
}
