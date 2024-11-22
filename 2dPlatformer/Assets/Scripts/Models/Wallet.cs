using System;
using UnityEngine;

namespace Models
{
    public class Wallet : MonoBehaviour
    {
        public int Coins { get; private set; } = 0;

        public event Action BalanceChanged;
        
        public void AddCoin()
        {
            Coins++;
            BalanceChanged?.Invoke();
        }
    }
}
