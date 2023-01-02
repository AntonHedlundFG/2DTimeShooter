using UnityEngine;

namespace TimeMultiplier
{
    public class TMStaticModifier : MonoBehaviour
    {
        public float TimeMultiplier = 0f;

        [SerializeField] private TMSystemHandler _eventHandler;

        private void OnEnable()
        {
            _eventHandler?.AddStaticModifier(this);
        }

        private void Start()
        {
            OnEnable();
        }

        private void OnDisable()
        {
            _eventHandler?.RemoveStaticModifier(this);
        }

    }
}

