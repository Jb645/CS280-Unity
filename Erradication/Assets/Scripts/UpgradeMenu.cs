using System;
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
        private bool _isAllowedToEvolveAttack,_isAllowedToEvolveHealth;
        private int _escalationAttack = 0;
        private int _escalationHealth = 0;
        public Image playerSprite;
        public PlayerStats player;
        public Button evolveButton, attackButton, healthButton;
        private int _interact;
        private int _statAugment = 0;
        public Text attackCostText, healthCostText, stageText;
        private int _evolutionStage =1;
        public Animator playerAnimator;
        private static readonly int Stage = Animator.StringToHash("Stage");

        public void Start()
        {
            evolveButton.interactable = false;
        }

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
            
            if (_isAllowedToEvolveAttack) return;
            var attackIncrease = 10 + _statAugment;
            var cost = 10 + _escalationAttack;
            
            var canBuyUpgrade =player.BuyUpgrades(cost,"attack",attackIncrease);
            if (!canBuyUpgrade) return;
            
            _escalationAttack += 5;
            if (_escalationAttack % 10 == 0)
            {
                attackButton.interactable = false;
                _isAllowedToEvolveAttack = true;
                AllowInteract();
            }
            attackCostText.text = $"{cost+5}";
            Debug.Log("Attack Increased");
        }
        public void IncreaseHealing()
        {
            if (_isAllowedToEvolveHealth) return;
            var healingIncrease = 5 + _statAugment;
            var cost = 10 + _escalationHealth;
            
            var canBuyUpgrade = player.BuyUpgrades(cost, "maxHealing", healingIncrease);
            if (!canBuyUpgrade) return;
            
            _escalationHealth += 5;
            if (_escalationHealth % 10 == 0)
            {
                healthButton.interactable = false;
                _isAllowedToEvolveHealth = true;
                AllowInteract();
            }
    
            healthCostText.text = $"{cost+5}";
            Debug.Log("Health Increased");
            
        }

        private void AllowInteract()
        {
            if (_evolutionStage >= 3) return;
            _interact += 1;
            if (_interact % 2 != 0) return;
            evolveButton.interactable = true;
            _interact = 0;
        }

        public void EvolveCreature()
        {
            if (!_isAllowedToEvolveAttack || !_isAllowedToEvolveHealth ||_evolutionStage>=3) return;
            _isAllowedToEvolveAttack = false;
            _isAllowedToEvolveHealth = false;
            attackButton.interactable = true;
            healthButton.interactable = true;
            evolveButton.interactable = false;
            _statAugment += 10;
            _evolutionStage += 1;
            playerAnimator.SetInteger(Stage,_evolutionStage);
            stageText.text = $"Evolution Stage: {_evolutionStage}";
            Debug.Log("Player Evolved");
        }
    }
}
