using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MenezesMovementSystem
{
    public class PlayerMovingState : PlayerGroundedState
    {
        public PlayerMovingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
        {
            
        }
    }
}
