using UnityEngine;
using System;

[System.Serializable]
public class PlayerDataclass
{

}


[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerData")]
public class PlayerData : ScriptableObject
{
    [SerializeField] private PlayerDataclass m_DataClass;
    public PlayerDataclass DataClass { get { return m_DataClass; } }
}
