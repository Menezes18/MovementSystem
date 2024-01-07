using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MenezesMovementSystem
{
    public class PlayerGroundedState : PlayerMovementState
    {
        public PlayerGroundedState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
        {
            
        }
        #region Reutilizaveis

        protected override void AddInputActionsCallback()
        {
            base.AddInputActionsCallback();
            stateMachine.Player.Input.PlayerActions.Movement.canceled += OnMovementCanceled;
        }


        protected override void RemoveInputActionsCallBack()
        {
            
            base.RemoveInputActionsCallBack();
            stateMachine.Player.Input.PlayerActions.Movement.canceled -= OnMovementCanceled;
        }
        protected virtual void OnMove()
        {
            if (shouldWalk)
            {
                stateMachine.ChangeState(stateMachine.WalkingState);
                return;
            }
            stateMachine.ChangeState(stateMachine.RunningState);
        }
        

        #endregion
        // METODOS INPUT
        #region Input Methods 

        private void OnMovementCanceled(InputAction.CallbackContext context)
        {
            stateMachine.ChangeState(stateMachine.IdlingState);
        }

        #endregion
    }
}
