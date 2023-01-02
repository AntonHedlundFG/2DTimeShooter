using UnityEngine;
using TimeMultiplier;

public abstract class Ability : ScriptableObject
{
    public Sprite SymbolSprite;
    public abstract void OnEquip(PlayerAbilityHandler playerAbilityHandler);
    public abstract void OnUnEquip();
    public abstract void OnKeyDown();
    public abstract void OnKeyUp();
}
