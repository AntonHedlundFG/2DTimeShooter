using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerFinder", menuName = "Playerfinder")]
public class PlayerFinder : ScriptableObject
{
    private GameObject _player;
    public void SetPlayer(GameObject player) => _player = player;
    public GameObject GetPlayer() => _player;

    public void RemovePlayer(GameObject removeObject) => _player = (_player == removeObject) ? null : _player;
}
