using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TimeMultiplier;

[CreateAssetMenu(fileName = "ProjectileAbility", menuName = "Abilities/Projectile")]
public class ProjectileAbility : Ability
{
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private float _cooldown;
    [SerializeField] private TMEvent _tmEvent;

    private float _lastUseTime = 0f;

    private PlayerAbilityHandler _playerAbilityHandler;

    public override void OnKeyDown()
    {
        if (_playerAbilityHandler.CooldownTime >= _lastUseTime + _cooldown)
        {
            Fire();
        }
    }

    private void Fire()
    {
        _lastUseTime = _playerAbilityHandler.CooldownTime; 
        _tmEvent.ActivateEvent(_playerAbilityHandler.TMSystemHandler);

        GameObject proj = Instantiate(_projectilePrefab, _playerAbilityHandler.transform.position, _playerAbilityHandler.transform.rotation);
        proj.transform.right = GetMousePos() - proj.transform.position;

    }

    public override void OnEquip(PlayerAbilityHandler playerAbilityHandler)
    {
        _playerAbilityHandler = playerAbilityHandler;
        _lastUseTime = _playerAbilityHandler.CooldownTime;
    }

    public override void OnUnEquip() { }

    public override void OnKeyUp() { }

    private Vector3 GetMousePos()
    {
        Vector3 tarPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        tarPos = new Vector3(tarPos.x, tarPos.y, 0);
        return tarPos;
    }
}
