using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace eradication
{
    public class DifficultyManager : MonoBehaviour
    {
        public static  int TotalTurns;
        private static bool _startedFromMenu = false;
        private enum Difficulty
        {
            Easy, Medium, Hard
        }

        [SerializeField] private Difficulty currentDifficulty = Difficulty.Easy;

        private void Start()
        {
            if (!_startedFromMenu)
            {
                TotalTurns = 30;//default
            }
        }

        public void ChangeDifficulty(int desiredDifficulty)
        {
            currentDifficulty = (Difficulty)desiredDifficulty;
            TotalTurns = currentDifficulty switch
            {
                Difficulty.Easy => 30,
                Difficulty.Medium => 20,
                Difficulty.Hard => 15,
                _ => TotalTurns
            };
            _startedFromMenu = true;
            SceneManager.LoadScene("Game");
        }
    }
}
