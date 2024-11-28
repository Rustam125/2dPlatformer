using Interfaces;
using UnityEngine;

namespace Models
{
    public class Coin : MonoBehaviour, IResource
    {
         [SerializeField] AudioClip _audioClip;

         public AudioClip AudioClip => _audioClip;
    }
}
