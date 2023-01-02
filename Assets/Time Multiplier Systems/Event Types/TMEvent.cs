using UnityEngine;

namespace TimeMultiplier
{
    public class TMEvent : ScriptableObject
    {
        [SerializeField] [Range(0f, 60f)] protected float _duration;
        [SerializeField] [Range(0f, 5f)] protected float _strength;

        protected float _lastCalledTime;


        public virtual void ActivateEvent(TMSystemHandler _eventHandler)
        {
            _lastCalledTime = Time.time;
            _eventHandler.RaiseEvent(this);
        }

        public virtual bool CheckEvent(out float strength)
        {
            strength = 0;
            return true;
        }
    }
}

