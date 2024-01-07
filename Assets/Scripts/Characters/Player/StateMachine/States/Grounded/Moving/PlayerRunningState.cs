using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MenezesMovementSystem
{
    public class PlayerRunningState : PlayerGroundedState
    {
        public PlayerRunningState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
        {
            
        }

        #region IState Methods

        public override void Enter()
        {
            base.Enter();
            speedModifier = 1f;
        }
        #endregion

        // METODOS INPUT
        #region Input Methods
        protected override void OnWalkToggleStarted(InputAction.CallbackContext context)
        {
            base.OnWalkToggleStarted(context);
            stateMachine.ChangeState(stateMachine.WalkingState);
        }

        #endregion
    }
}
