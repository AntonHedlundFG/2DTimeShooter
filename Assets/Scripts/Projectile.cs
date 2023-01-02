using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TimeMultiplier;

[RequireComponent(typeof(TMFloat))][RequireComponent(typeof(BoxCollider2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField] [Range(0.0f, 30f)] private float _speed = 1f;
    //[SerializeField] [Range(0.0f, 100f)] private float _damage = 10f;
    [SerializeField] [Range(0.0f, 30f)] private float _maxDuration = 5f;

    private TMFloat _multiplier;
    private BoxCollider2D _collider;

    private float _curDuration;

    private void Start()
    {
        _multiplier = GetComponent<TMFloat>();
        _collider = GetComponent<BoxCollider2D>();
        _curDuration = 0f;
        _collider.isTrigger = true;
    }

    private void Update()
    {
        MoveForward();
        UpdateDuration();
    }

    private void UpdateDuration()
    {
        _curDuration += Time.deltaTime * _multiplier.GetValue();
        if (_curDuration >= _maxDuration)
        {
            Destroy(gameObject);
        }
    }

    private void MoveForward()
    {
        float speed = _speed * Time.deltaTime * _multiplier.GetValue();
        transform.position += transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            Destroy(gameObject);
        }
    }
}
