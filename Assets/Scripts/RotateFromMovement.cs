using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RotateFromMovement : MonoBehaviour
{
    private Rigidbody2D _rb;

    //[SerializeField] private float _rotateSpeed = 180f;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 vel = _rb.velocity;
        if (vel.sqrMagnitude > 0.01f)
        {
            float angle = Mathf.Atan2(vel.y, vel.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
