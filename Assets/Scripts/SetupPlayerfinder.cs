using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupPlayerfinder : MonoBehaviour
{
    [SerializeField] private PlayerFinder _pf;

    private void Awake()
    {
        _pf.SetPlayer(gameObject);
    }

    private void OnDestroy()
    {
        _pf.RemovePlayer(gameObject);
    }
}
