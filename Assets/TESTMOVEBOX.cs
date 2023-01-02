using UnityEngine;
using TimeMultiplier;

[RequireComponent(typeof(TMFloat))]
[RequireComponent(typeof(Rigidbody2D))]
public class TESTMOVEBOX : MonoBehaviour
{
    private TMFloat _tmFloat;
    private Rigidbody2D _rb;
    void Start()
    {
        _tmFloat = GetComponent<TMFloat>();
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = Vector2.right * _tmFloat.GetValue();
    }
}
