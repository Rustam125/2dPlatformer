using UnityEngine;

namespace Models
{
    public class AnimatedCharacter : MonoBehaviour
    {
        public bool IsGrounded { get; set; }
        public bool IsRunning { get; set; }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.GetComponent<Ground>())
            {
                IsGrounded = true;
            }
        }
    }
}
