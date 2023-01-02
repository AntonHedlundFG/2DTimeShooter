using UnityEngine;
using TimeMultiplier;

[CreateAssetMenu(fileName = "TeleportAbility", menuName = "Abilities/Teleport")]
public class TeleportAbility : Ability
{
    [SerializeField] private float _cooldown;
    [SerializeField] private float _distance;
    [SerializeField] private bool _canPassThroughObjects;
    [SerializeField] private LayerMask _mask;

    [SerializeField] private TMEvent _tmEvent;

    private float _lastUseTime = 0f;
    private PlayerAbilityHandler _playerAbilityHandler;

    public override void OnEquip(PlayerAbilityHandler playerAbilityHandler)
    {
        _playerAbilityHandler = playerAbilityHandler;
        _lastUseTime = _playerAbilityHandler.CooldownTime;
    }

    public override void OnKeyDown()
    {
        if (_playerAbilityHandler.CooldownTime >= _lastUseTime + _cooldown)
        {
            _lastUseTime = _playerAbilityHandler.CooldownTime;
            _tmEvent.ActivateEvent(_playerAbilityHandler.TMSystemHandler);
            Teleport();
        }

    }
    
    private void Teleport()
    {
        if (!_canPassThroughObjects)
        {
            TeleportTowards();
            return;
        }

        BoxCollider2D boxCollider = _playerAbilityHandler.GetComponent<BoxCollider2D>();

        Vector3 tarPos = GetMousePos();
        Vector3 curPos = boxCollider.transform.position;
        Vector3 dir = tarPos - curPos;

        if (dir.magnitude > _distance)
        {
            tarPos = curPos + dir.normalized * _distance;
            dir = tarPos - curPos;
        }


        Collider2D result = Physics2D.OverlapBox(tarPos, boxCollider.size, boxCollider.transform.eulerAngles.z, _mask);

        if (result == null)
        {
            boxCollider.transform.position = tarPos;
            return;
        }
        TeleportTowards();
    }

    private void TeleportTowards()
    {
        BoxCollider2D boxCollider = _playerAbilityHandler.GetComponent<BoxCollider2D>();
        
        Vector3 tarPos = GetMousePos();
        Vector3 curPos = boxCollider.transform.position;
        Vector3 dir = tarPos - curPos;

        if (dir.magnitude > _distance)
        {
            tarPos = curPos + dir.normalized * _distance;
            dir = tarPos - curPos;
        }


        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.transform.position, boxCollider.size, boxCollider.transform.eulerAngles.z, dir, dir.magnitude, _mask);

        if (hit.collider == null)
        {
            boxCollider.transform.position = tarPos;
            return;
        }

        boxCollider.transform.position = hit.point - dir.normalized * boxCollider.size / 2;

    }

    private Vector3 GetMousePos()
    {
        Vector3 tarPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        tarPos = new Vector3(tarPos.x, tarPos.y, 0);
        return tarPos;
    }

    public override void OnKeyUp() { }

    public override void OnUnEquip() { }
}
