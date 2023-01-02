using System.Collections.Generic;
using UnityEngine;

namespace TimeMultiplier
{
    [CreateAssetMenu(fileName = "TM System Handler", menuName = "Time Multiplier/Handler")]
    public class TMSystemHandler : ScriptableObject
    {
        private TMBrain _brain;

        public void SetBrain(TMBrain brain)
        {
            Debug.Log("Here?");
            _brain = brain;
        }

        public void RemoveBrain(TMBrain brain)
        {
            if (_brain == brain)
            {
                _brain = null;
            }
        }

        public void RaiseEvent(TMEvent timeMultEvent)
        {
            _brain.RaiseEvent(timeMultEvent);
        }

        public void AddStaticModifier(TMStaticModifier modifier)
        {
            _brain?.RaiseStaticModifier(modifier);
        }

        public void RemoveStaticModifier(TMStaticModifier modifier)
        {
            _brain?.RemoveStaticModifier(modifier);
        }

        public TMBrain GetBrain() => _brain;

        public void SetPauseState(GamePauseSystem.PauseStates state) => _brain.SetPauseState(state);
    }
}

