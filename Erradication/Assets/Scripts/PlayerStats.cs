using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace eradication
{
    public class PlayerStats : MonoBehaviour
    {
        private int _evolutionStage, _attack, _health, _evos;
        public Text evolutionStageText, attackText, healthText, evoText;
        public Continent playerLocation;
        private void Start()
        {
            _evolutionStage = 1;
            _attack = 10;
            _health = 100;
            _evos = 0;
            evolutionStageText.text = $"Evolution Stage: {_evolutionStage.ToString()}";
            attackText.text = $"Attack: {_attack.ToString()}";
            healthText.text = _health.ToString();
            evoText.text = $"Evos: {_evos}";
        }

        public void Heal(int amountOfHealth)
        {
            _health += amountOfHealth;
            healthText.text = _health.ToString();
        }

        public void TakeDamage()
        {
            var damage = playerLocation.DamagePlayer();
            _health -= damage;
            healthText.text = _health.ToString();
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

        public void BuyUpgrades(int cost)
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

            evoText.text = $"Evos: {_evos}";
        }

        public void CurrentLocation(Continent currentContinent)
        {
            playerLocation = currentContinent;
        }
    }
}
