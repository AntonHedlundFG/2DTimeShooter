using UnityEngine;

namespace TimeMultiplier
{
    public class TMFloat : MonoBehaviour
    {
        [SerializeField] private TMSystemHandler _eventHandler;

        private TMBrain _brain;

        private void Start()
        {
            if (_eventHandler != null)
            {
                _brain = _eventHandler.GetFirstBrain();
            }
        }

        public float GetValue() => _brain == null ? 0 : _brain.GetMultiplier();

    }

}
