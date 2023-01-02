using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : Decision
{
    public bool Moving;
    [SerializeField] PlayerFinder _playerFinder;
    private Rigidbody2D _playerRB;
    private bool _foundPlayer = false;

    public override bool CheckDecision()
    {
        if (!_foundPlayer)
        {
            _playerRB = _playerFinder.GetPlayer().GetComponent<Rigidbody2D>();
            if (_playerRB != null)
            {
                _foundPlayer = true;
            } else
            {
                return !Moving;
            }
        }
        return Moving == (_playerRB.velocity.sqrMagnitude > 0.01);
    }
}
