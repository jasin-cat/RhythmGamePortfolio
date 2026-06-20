using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerData")]
public class PlayerData : ScriptableObject
{
    [SerializeField]
    private int _players;
    public int Players => _players;

    public void Init()
    {
        _players = 0;
    }

    public void AddPlayers()
    {
        _players++;
    }

    public void RemovePlayers()
    {
        _players--;
    }
}
