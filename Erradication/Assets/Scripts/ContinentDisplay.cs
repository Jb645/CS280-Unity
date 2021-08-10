using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace eradication
{
    public class ContinentDisplay : MonoBehaviour
    {
        public Continent[] continentArray;
        public PlayerStats player;
        public Text nameText, attackText, healthText;
        private int currentContinent;
        private void Start()
        {
            foreach (var continent in continentArray)
            {
                continent.Start();
            }
            currentContinent = 0;
            nameText.text = continentArray[0].name;
            attackText.text = $"Continent Attack: {continentArray[0].attack.ToString()}";
            healthText.text = $"Health: {continentArray[0].health.ToString()} %";
        }

        public void ChangeContinent(int theContinent)
        {
            if (theContinent > continentArray.Length - 1)
            {
                Debug.LogError("Invalid Number");
                return;
            }

            currentContinent = theContinent;
            nameText.text = continentArray[theContinent].name;
            attackText.text = $"Continent Attack: {continentArray[theContinent].attack.ToString()}";
            healthText.text = $"Health: {continentArray[theContinent].health.ToString()} %";
            player.CurrentLocation(continentArray[theContinent]);
        }

        public void UpdateCurrentContinentText()
        {
            attackText.text = $"Continent Attack: {continentArray[currentContinent].attack.ToString()}";
            healthText.text = $"Health: {continentArray[currentContinent].health.ToString()} %";
            player.CurrentLocation(continentArray[currentContinent]);
        }
    }
}
