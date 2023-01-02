using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _followTarget;

    // Update is called once per frame
    void Update()
    {
        if (_followTarget == null) { return; }

        Vector3 pos = new Vector3(_followTarget.position.x, _followTarget.position.y, transform.position.z);
        transform.position = pos;
    }
}
