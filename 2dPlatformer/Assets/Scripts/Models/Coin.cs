using Interfaces;
using UnityEngine;

namespace Models
{
    public class Coin : MonoBehaviour, IResource
    {
         [SerializeField] private AudioClip _audioClip;

         public AudioClip AudioClip => _audioClip;
    }
}
