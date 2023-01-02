using System.Collections.Generic;
using UnityEngine;

namespace TimeMultiplier
{
    public class TMBrain : MonoBehaviour
    {
        [SerializeField] private TMSystemHandler _targetEventHandler;
        private TMSystemHandler _subscribedEventHandler;

        private List<TMEvent> _timeMultEvents = new List<TMEvent>();
        private List<TMStaticModifier> _staticModifiers = new List<TMStaticModifier>();

        [SerializeField] private float TimeMultiplier;

        public float GetMultiplier() => TimeMultiplier;

        private void OnEnable()
        {
            if (_targetEventHandler != null)
            {
                _targetEventHandler.AddBrain(this);
                _subscribedEventHandler = _targetEventHandler;
            }

        }

        private void OnDisable()
        {
            if (_subscribedEventHandler != null)
            {
                _subscribedEventHandler.RemoveBrain(this);
                _subscribedEventHandler = null;
            }
        }

        public void RaiseStaticModifier(TMStaticModifier modifier)
        {
            if (!_staticModifiers.Contains(modifier))
            {
                _staticModifiers.Add(modifier);
            }
        }

        public void RemoveStaticModifier(TMStaticModifier modifier)
        {
            _staticModifiers.Remove(modifier);
        }

        public void RaiseEvent(TMEvent timeMultEvent)
        {
            if (!_timeMultEvents.Contains(timeMultEvent))
            {
                _timeMultEvents.Add(timeMultEvent);
            }
        }

        public void Update()
        {
            float max = 0;

            for (int i = _timeMultEvents.Count - 1; i >= 0; i--)
            {
                float s;
                if (_timeMultEvents[i].CheckEvent(out s))
                {
                    _timeMultEvents.RemoveAt(i);
                }
                max = Mathf.Max(max, s);
            }
            for (int i = _staticModifiers.Count - 1; i >= 0; i--)
            {
                max = Mathf.Max(max, _staticModifiers[i].TimeMultiplier);
            }
            TimeMultiplier = max;
        }

    }

}