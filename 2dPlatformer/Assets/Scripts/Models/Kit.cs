using Interfaces;
using UnityEngine;

namespace Models
{
    public class Kit : MonoBehaviour, IResource
    {
        [SerializeField] private float _healPoints = 10f;
        [SerializeField] private AudioClip _audioClip;

        public AudioClip AudioClip => _audioClip;
        public float HealPoints => _healPoints;
    }
}