using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitySymbolsUI : MonoBehaviour
{
    [SerializeField] private PlayerAbilityHandler _abilityHandler;

    [SerializeField] private Image[] _images = new Image[PlayerAbilityHandler.ABILITYCOUNT];

    private void OnValidate()
    {
        if (_images.Length != PlayerAbilityHandler.ABILITYCOUNT)
        {
            Debug.LogWarning("You can't change the size of this array");
            Array.Resize(ref _images, PlayerAbilityHandler.ABILITYCOUNT);
        }
    }

    private void Start()
    {
        UpdateSymbols();
    }

    private void UpdateSymbols()
    {
        if (_abilityHandler == null) { return; }

        for (int i = 0; i < _images.Length; i++)
        {
            _images[i].sprite = _abilityHandler.GetSprite(i);
        }
    }
}
