using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class JoinPlayer : MonoBehaviour
{
    private const int MAX_PLAYER_NUM = 4;
    [SerializeField]
    Button _joinButton;
    [SerializeField]
    Button _RemoveButton;
    [SerializeField]
    InputAction _anyClickStart;
    [SerializeField]
    PlayerData _playerData;
    [SerializeField]
    private List<GameObject> _players;
    [SerializeField]
    private TextMeshProUGUI text;
    [SerializeField]
    private StartButtonTxtAnimation _animTxt;
    private InputHandler _input;

    void Awake()
    {
        _input = new();
        _animTxt.gameObject.SetActive(false);
        _playerData.Init();
        _joinButton.onClick.AddListener(() =>
        {
            if(_playerData.Players == MAX_PLAYER_NUM) return;
            OnJoin();
            
            if(_playerData.Players == 2)
            {
                _input.Init();
                _animTxt.gameObject.SetActive(true);
            }
        });

        _RemoveButton.onClick.AddListener(() =>
        {
            if(_playerData.Players == 0) return;
            OnRemove();
            
            if(_playerData.Players == 1)
            {
                _input.Disable();
                _animTxt.gameObject.SetActive(false);
            }
        });
    }

    void OnJoin()
    {
        if(_playerData.Players > MAX_PLAYER_NUM) return;
        _players[_playerData.Players].SetActive(true);
        _playerData.AddPlayers();
    }

    void OnRemove()
    {
        if(_playerData.Players <= 0) return;
        _playerData.RemovePlayers();
        _players[_playerData.Players].SetActive(false);
    }
}
