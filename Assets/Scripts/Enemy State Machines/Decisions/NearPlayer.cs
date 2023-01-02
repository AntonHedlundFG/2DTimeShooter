using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearPlayer : Decision
{
    public bool Near;
    public float _distance = 5f;
    [SerializeField] private PlayerFinder _playerFinder;
    private GameObject _player;
    private bool _foundPlayer = false;

    public override bool CheckDecision()
    {
        if (!_foundPlayer)
        {
            _player = _playerFinder.GetPlayer();
            if (_player != null)
            {
                _foundPlayer = true;
            }
            else
            {
                return false;
            }
        }

        return ((_player.transform.position - transform.position).magnitude < _distance) == Near;

    }
}
