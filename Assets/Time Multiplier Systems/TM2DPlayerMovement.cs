using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimeMultiplier
{
    [RequireComponent(typeof(Rigidbody2D))][RequireComponent(typeof(TMStaticModifier))]
    public class TM2DPlayerMovement : MonoBehaviour
    {
        private TMStaticModifier _staticMod;
        private Rigidbody2D _rb;

        [SerializeField] [Range(1f, 30f)] private float _moveSpeed = 10f;
        [SerializeField] [Range(1f, 100f)] private float _acceleration = 10f;
        [SerializeField] [Range(0.1f, 10f)] private float _maxMult = 1;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _rb.drag = 0f;
            _rb.gravityScale = 0;

            _staticMod = GetComponent<TMStaticModifier>();
        }

        private void Update()
        {
            MoveFromInput();
            UpdateMultiplier();
        }

        private void MoveFromInput()
        {
            Vector2 targetSpd = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * _moveSpeed;
            Vector2 curSpd = _rb.velocity;
            Vector2 difSpd = targetSpd - curSpd;
            
            float accdelta = _acceleration * Time.deltaTime;

            _rb.velocity += difSpd.magnitude <= accdelta ? difSpd : difSpd.normalized * accdelta;
            
        }

        private void UpdateMultiplier() => _staticMod.TimeMultiplier = Mathf.Lerp(0f, _maxMult, _rb.velocity.magnitude / _moveSpeed);
    }
}

