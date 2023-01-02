using UnityEngine;

namespace TimeMultiplier
{
    [CreateAssetMenu(fileName = "EaseInOutSineTMEvent", menuName = "Time Multiplier/Events/Ease In Out Sine")]
    public class TMEventEaseInOutSine : TMEvent
    {
        public override bool CheckEvent(out float strength)
        {
            float t = Mathf.InverseLerp(_lastCalledTime, _lastCalledTime + _duration, Time.time);
            t = Mathf.Clamp(t, 0, 1);
            strength = _strength * (1 + Mathf.Cos(Mathf.PI * t)) / 2;

            return Time.time >= _lastCalledTime + _duration;
        }
    }

}
