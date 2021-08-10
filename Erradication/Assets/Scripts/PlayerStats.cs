using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace eradication
{
    public class PlayerStats : MonoBehaviour
    {
        [SerializeField]private int _evolutionStage, _attack, _health, _evos, _maxHealth;
        public Text evolutionStageText, attackText, healthText, evoText;
        public Continent playerLocation;
        public GameProgression progressionManager;
        private void Start()
        {
            _evolutionStage = 1;
            _attack = 10;
            _health = 100;
            _evos = 0;
            _maxHealth = 100;
            evolutionStageText.text = $"Evolution Stage: {_evolutionStage.ToString()}";
            attackText.text = $"Attack: {_attack.ToString()}";
            healthText.text = $"HP: {_health.ToString()}/{_maxHealth}";
            evoText.text = $"Evos: {_evos}";
            
        }

        

        public void TakeDamage()
        {
          
            if (_health <= 0)
            {
                _health = 0;
                progressionManager.ChangeCurrentCondition(1); //lose
                return;
            }
            var damage = playerLocation.DamagePlayer();
            _health -= damage;
            if (_health > _maxHealth)
            {
                _health = _maxHealth;
            }
            healthText.text = $"HP: {_health.ToString()}/{_maxHealth}";
        }

        public void DealDamage()
        {
            playerLocation.ContinentTakeDamage(_attack);
        }

        public void ChangeEvos(int passiveIncrease)
        {
            _evos += passiveIncrease;
            evoText.text = $"Evos: {_evos}";
        }

        public void BuyUpgrades(int cost, string statName, int statIncrease)
        {
            var afterCostEvos = _evos - cost;
            if (_evos - cost < 0)
            {
                Debug.LogError("not Enough Evos");
            }
            else
            {
                _evos = afterCostEvos;
            }

            switch (statName)
            {
                case "attack":
                    _attack += statIncrease;
                    break;
                case "maxHealth":
                    _maxHealth += statIncrease;
                    break;
            }

            evoText.text = $"Evos: {_evos}";
        }

        public void CurrentLocation(Continent currentContinent)
        {
            playerLocation = currentContinent;
        }
    }
}
