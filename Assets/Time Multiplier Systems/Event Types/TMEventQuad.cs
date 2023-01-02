using UnityEngine;

namespace TimeMultiplier
{
    [CreateAssetMenu(fileName = "QuadraticTimeMultEvent", menuName = "Time Multiplier/Events/Quadratic")]
    public class TMEventQuad : TMEvent
    {
        public override bool CheckEvent(out float strength)
        {
            float t = Mathf.InverseLerp(_lastCalledTime, _lastCalledTime + _duration, Time.time);
            t = Mathf.Clamp(t, 0, 1);
            strength = Mathf.Lerp(_strength, 0, t * t);

            return Time.time >= _lastCalledTime + _duration;
        }
    }
}

