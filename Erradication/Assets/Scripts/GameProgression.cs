using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        [SerializeField] private int passiveEvoIncrease = 1;
        public Text turnsText;
        
        

        private void Start()
        {
            results.SetActive(false);
        }

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Space)) return;
            FinishTurn();
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
            if (turn >= difficulty.totalTurns)
            {
                results.SetActive(true);
                winOrLoseText.text = "lose";
                return;
            }
            turn += 1;
            turnsText.text = $"Turns: {turn.ToString()}/{difficulty.totalTurns}";
            
            //check how many continents are conquered
            var totalContinentConquered = 
                continents.continentArray.TakeWhile(continent => continent.conquered).Count();
            var totalEvosGained = passiveEvoIncrease + totalContinentConquered;
            //give player points depending on the places conquered and passive gain
            player.ChangeEvos(totalEvosGained);
            
            //make player take damage
            player.TakeDamage();
            
            //make player deal damage
            player.DealDamage();
            
            
            //make player win if all places have been conquered
            if (totalContinentConquered != 7) return;
            results.SetActive(true);
            winOrLoseText.text = "win";


        }

    }
}
