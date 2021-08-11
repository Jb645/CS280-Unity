using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

namespace eradication
{
    [CreateAssetMenu(fileName = "New Continent", menuName = "Continents")]
    public class Continent : ScriptableObject
    {
        public new string name;
        public int attack;
        public int health = 100;
        public bool conquered = false;

        public void Start()
        {
            if (IsItAntartica()) return;
            health = 100;
            conquered = false;
        }

        private void Conquer()
        {
            conquered = true;
        }

        public int DamagePlayer()
        {
            if (!IsItAntartica()) return !conquered ? attack : -10;
            Debug.Log("is antartica");
            return -10; //player heals
        }

        public bool IsItAntartica()
        {
            return name == "Antartica";
        }
        
        public void ContinentTakeDamage(int playerAttack)
        {
            if (health <= 0) //checking fi the health of continent is not less than 0
            {
                health = 0;
                if (!conquered)
                {
                    Conquer();
                }
                return;
            }
            health -= playerAttack;
        }
    }
    
}
