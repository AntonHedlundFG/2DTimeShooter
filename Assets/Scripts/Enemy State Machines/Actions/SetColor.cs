using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColor : Action
{
    public Renderer Renderer;
    public bool Permanent = false;
    public Color Color = Color.white;

    private Color _tempColor;
    public override void OnEnter()
    {
        _tempColor = Renderer.material.color;
        Renderer.material.color = Color;
    }

    public override void OnExit()
    {
        if (!Permanent)
        {
            Renderer.material.color = _tempColor;
        }
    }

    public override void OnUpdate()
    {
    }
}
