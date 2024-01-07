using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MenezesMovementSystem
{
    /// <summary>
    /// Classe de objeto de scriptable para representar um jogador.
    /// </summary>
    [CreateAssetMenu(fileName = "Player", menuName = "Custom/Characters/Player")]
    public class PlayerSO : ScriptableObject
    {
        /// <summary>
        /// Dados de movimentação do jogador quando no chão.
        /// </summary>
        [field:SerializeField]
        [Tooltip("Dados de movimentação do jogador quando no chão.")]
        public PlayerGroundedData GroundedData { get; private set; }
    
        /*
        - GroundedData.BaseSpeed: Velocidade base de movimento do jogador no chão.
        - GroundedData.BaseRotationData: Dados de rotação base do jogador no chão.
        - GroundedData.WalkData: Dados de movimentação de caminhada do jogador no chão.
        - GroundedData.RunData: Dados de movimentação de corrida do jogador no chão.
        */
    }

}
