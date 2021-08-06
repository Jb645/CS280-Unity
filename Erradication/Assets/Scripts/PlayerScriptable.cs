using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace eradication
{   
    [CreateAssetMenu(fileName = "new Player", menuName = "Player")]
    public class PlayerScriptable : ScriptableObject
    {
        public int evolutionStage, evos, attack, turns, totalTurns;
    }
}
