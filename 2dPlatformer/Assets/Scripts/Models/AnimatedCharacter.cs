using UnityEngine;

namespace Models
{
    public class AnimatedCharacter : MonoBehaviour
    {
        public bool IsGrounded { get; private set; }
        public bool IsRunning { get; set; }
        public bool IsHitting { get; set; }
        public bool IsTakingDamage { get; set; }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            SetIsGrounded(other, true);
        }
        
        private void OnCollisionExit2D(Collision2D other)
        {
            SetIsGrounded(other, false);
        }
        
        private void SetIsGrounded(Collision2D other, bool value)
        {
            if (other.gameObject.GetComponent<Ground>())
            {
                IsGrounded = value;
            }
        }
    }
}
