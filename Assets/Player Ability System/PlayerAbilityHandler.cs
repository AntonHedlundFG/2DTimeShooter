using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TimeMultiplier;

public class PlayerAbilityHandler : MonoBehaviour
{
    public const int ABILITYCOUNT = 4;
    [SerializeField] private Ability[] _abilities = new Ability[ABILITYCOUNT];
    [SerializeField] private KeyCode[] _abilityHotkeys = new KeyCode[ABILITYCOUNT];

    [SerializeField] public TMSystemHandler TMSystemHandler;
    [SerializeField] private GamePauseSystem _gamePauseSystem;

    public float CooldownTime;

    private void OnValidate()
    {
       if (_abilities.Length != ABILITYCOUNT)
        {
            Debug.LogWarning("You can't change the size of this array");
            Array.Resize(ref _abilities, ABILITYCOUNT);
        }
       if (_abilityHotkeys.Length != ABILITYCOUNT)
        {
            Debug.LogWarning("You can't change the size of this array");
            Array.Resize(ref _abilityHotkeys, ABILITYCOUNT);
        }
    }

    private void Update()
    {
        if (_gamePauseSystem.GetPauseState() != GamePauseSystem.PauseStates.Pause)
        {
            CheckHotkeys();
            UpdateCooldown();
        }
    }

    private void UpdateCooldown()
    {
        CooldownTime += Time.deltaTime;
    }

    private void CheckHotkeys()
    {
        for (int i = 0; i < _abilityHotkeys.Length; i++)
        {
            if(Input.GetKeyDown(_abilityHotkeys[i]))
            {
                _abilities[i].OnKeyDown();
            }
            if (Input.GetKeyUp(_abilityHotkeys[i]))
            {
                _abilities[i].OnKeyUp();
            }
        }
    }

    private void Awake()
    {
        foreach(Ability ability in _abilities)
        {
            ability?.OnEquip(this);
        }
        CooldownTime = 0f;
    }

    public Sprite GetSprite(int abilityIndex)
    {
        return _abilities[abilityIndex].SymbolSprite;
    }
}
