using UnityEngine;

namespace Models
{
    public class Kit : MonoBehaviour
    {
        [SerializeField] private float _healPoints = 10f;
        
        public float HealPoints => _healPoints;
    }
}