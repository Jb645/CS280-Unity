using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace eradication
{
    [CreateAssetMenu(fileName = "New Continent", menuName = "Continents")]
    public class Continent : ScriptableObject
    {
        public new string name;
        public int attack;
        public int health = 100;
        public bool conquered = false;
        
        public void Conquer()
        {
            conquered = true;
        }

        public int DamagePlayer()
        {
            return !conquered ? attack : 0;
        }

        public void ContinentTakeDamage(int playerAttack)
        {
            health -= playerAttack;
        }
    }
    
}
