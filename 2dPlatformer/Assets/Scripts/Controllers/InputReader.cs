using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Controllers
{
    public class InputReader : MonoBehaviour
    {
        private const string Horizontal = nameof(Horizontal);
        private const string JumpButton = "Jump";
        private const int AttackMouseButton = (int)MouseButton.Left;

        public event Action<float> Moved;
        public event Action Jumped;
        public event Action Attacked;
        public event Action AttackCompleted;

        private void Update()
        {
            Moved?.Invoke(Input.GetAxis(Horizontal));
            
            if (Input.GetButtonDown(JumpButton))
            {
                Jumped?.Invoke();
            }

            if (Input.GetMouseButtonDown(AttackMouseButton))
            {
                Attacked?.Invoke();
            }
            else
            {
                AttackCompleted?.Invoke();
            }
        }
    }
}