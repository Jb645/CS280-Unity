using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

namespace eradication
{
    public class GameProgression : MonoBehaviour
    {
        [SerializeField] private int turn;
        public DifficultyManager difficulty;
        public PlayerStats player;
        public ContinentDisplay continents;
        public Text winOrLoseText;
        public GameObject results;
        public Text turnsText;
        

        enum PlayerCondition
        {
            Win, Lose, Playing
        }

        private PlayerCondition _gameplayCurrentResults = PlayerCondition.Playing;

        //add wining conditions
        public void ChangeCurrentCondition(int conditionNumber)
        {
            if (conditionNumber < 0 || conditionNumber >= 3)
            {
                Debug.LogError("Invalid Condition Number");
                return;
            }
            _gameplayCurrentResults = (PlayerCondition)conditionNumber;
        }

        

        //increase the number of turns -
        //set lose if the total turns is passed -
        //set win if all continentArray are conquered-
        //give evos to player-
        //make player take damage
        //make the game end when win or lose
        private void FinishTurn()
        {
            
            //change turn
            if (turn >= DifficultyManager.TotalTurns||_gameplayCurrentResults != PlayerCondition.Playing)
            {
                Debug.Log("works");
                results.SetActive(true);
                winOrLoseText.text = "YOU LOSE";
                _gameplayCurrentResults = PlayerCondition.Lose;
                return;
            }
            turn += 1;
            turnsText.text = $"Turns: {turn.ToString()}/{DifficultyManager.TotalTurns}";

            //check how many continents are conquered
            var totalContinentConquered = continents.continentArray.Count(continent => continent.conquered);
            
            //var totalEvosGained = passiveEvoIncrease + totalContinentConquered;
            //give player points depending on the places conquered and passive gain
            player.ChangeEvos(totalContinentConquered);
            
            //make player take damage
            
            player.TakeDamage();
            
            //make player deal damage
            player.DealDamage();
            continents.UpdateCurrentContinentText();
            
            
            //make player win if all places have been conquered
            if (totalContinentConquered != 7) return;
            results.SetActive(true);
            winOrLoseText.text = "YOU WIN";
            _gameplayCurrentResults = PlayerCondition.Win;


        }
        
        private void Start()
        {
            results.SetActive(false);
            turnsText.text = $"Turns: {turn.ToString()}/{DifficultyManager.TotalTurns}";
            
        }

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Space)) return;
            FinishTurn();
        }

    }
}
