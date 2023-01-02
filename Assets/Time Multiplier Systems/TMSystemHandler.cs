using System.Collections.Generic;
using UnityEngine;

namespace TimeMultiplier
{
    [CreateAssetMenu(fileName = "TM System Handler", menuName = "Time Multiplier/Handler")]
    public class TMSystemHandler : ScriptableObject
    {
        private List<TMBrain> _brains = new List<TMBrain>();

        public void AddBrain(TMBrain brain)
        {
            if (!_brains.Contains(brain))
            {
                _brains.Add(brain);
            }
        }

        public void RemoveBrain(TMBrain brain)
        {
            _brains.Remove(brain);
        }

        public void RaiseEvent(TMEvent timeMultEvent)
        {
            for (int i = _brains.Count - 1; i >= 0; i--)
            {
                _brains[i].RaiseEvent(timeMultEvent);
            }
        }

        public void AddStaticModifier(TMStaticModifier modifier)
        {
            for (int i = _brains.Count - 1; i >= 0; i--)
            {
                _brains[i].RaiseStaticModifier(modifier);
            }
        }

        public void RemoveStaticModifier(TMStaticModifier modifier)
        {
            for (int i = _brains.Count - 1; i >= 0; i--)
            {
                _brains[i].RemoveStaticModifier(modifier);
            }
        }

        public TMBrain GetFirstBrain() => _brains.Count > 0 ? _brains[0] : null;

    }
}

