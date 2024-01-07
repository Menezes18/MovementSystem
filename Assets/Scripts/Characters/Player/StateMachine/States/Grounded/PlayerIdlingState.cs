using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace MenezesMovementSystem
{
    public class PlayerIdlingState : PlayerGroundedState
    {
        public PlayerIdlingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
        {
            
        }

        #region Istate Methods
        public override void Enter()
        {
            base.Enter();
            stateMachine.ReusableData.MovementSpeedModifier = 0f;
            ResetVelocity();
        }

        public override void Update()
        {
            base.Update();
            if (stateMachine.ReusableData.MovementInput == Vector2.zero)
            {
                return;
                
            }

            OnMove();
        }



        #endregion
    }
}
