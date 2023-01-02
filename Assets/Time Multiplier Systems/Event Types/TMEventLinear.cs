using UnityEngine;

namespace TimeMultiplier
{
    [CreateAssetMenu(fileName = "LinearTMEvent", menuName = "Time Multiplier/Events/Linear")]
    public class TMEventLinear : TMEvent
    {
        public override bool CheckEvent(out float strength)
        {
            float t = Mathf.InverseLerp(_lastCalledTime, _lastCalledTime + _duration, Time.time);
            t = Mathf.Clamp(t, 0, 1);
            strength = Mathf.Lerp(_strength, 0, t);

            return Time.time >= _lastCalledTime + _duration;
        }
    }
}

