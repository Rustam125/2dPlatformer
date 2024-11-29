using System;
using UnityEngine;

namespace Models
{
    public class Wallet : MonoBehaviour
    {
        public event Action BalanceChanged;
        
        public int Coins { get; private set; } = 0;

        public void AddCoin()
        {
            Coins++;
            BalanceChanged?.Invoke();
        }
    }
}
