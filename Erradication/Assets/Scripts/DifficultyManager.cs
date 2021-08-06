using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace eradication
{
    public class DifficultyManager : MonoBehaviour
    {
        public int totalTurns;
        public enum Difficulty
        {
            Easy, Medium, Hard
        }

        [SerializeField] private Difficulty current = Difficulty.Easy;

        private void Start()
        {
            totalTurns = 30;//default
        }

        public void ChangeDifficulty(Difficulty desiredDifficulty)
        {
            current = desiredDifficulty;
            totalTurns = current switch
            {
                Difficulty.Easy => 30,
                Difficulty.Medium => 20,
                Difficulty.Hard => 15,
                _ => totalTurns
            };
        }
    }
}
