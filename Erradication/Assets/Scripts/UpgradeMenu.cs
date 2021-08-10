using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace eradication
{
    public class UpgradeMenu : MonoBehaviour
    {
        public GameObject upgradeMenu;
        public Text openingButton;
        private bool _isMenuOpen;
        private bool _isAllowedToEvolve;
        public PlayerStats player;
        public void OpenUpgradeMenu()
        {
            if (!_isMenuOpen)
            {
                upgradeMenu.transform.Translate(-500,0,0); //move left (open)
                _isMenuOpen = true;
                openingButton.text = "> >";
            }
            else
            {
                upgradeMenu.transform.Translate(500,0,0); //move right (close)
                _isMenuOpen = false;
                openingButton.text = "< <";
            }
            
        }

        public void IncreaseAttack()
        {
            
        }
        public void IncreaseHealth()
        {
            
        }

        public void EvolveCreature()
        {
            if (_isAllowedToEvolve)
            {
                
            }
        }
    }
}
