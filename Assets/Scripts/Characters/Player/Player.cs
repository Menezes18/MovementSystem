using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MenezesMovementSystem
{
    public class Player : MonoBehaviour
    {
        private PlayerMovementStateMachine _movementStateMachine; //chamando a ref do state machine para passar os parametros 


        private void Awake()
        {
            _movementStateMachine = new PlayerMovementStateMachine();
        }

        private void Start()
        {
            _movementStateMachine.ChangeState(_movementStateMachine.IdlingState); // vai passar sempre o idle quando o jogo começars
        }

        private void Update()
        {
            //Dados de Entrada Atualizado
            _movementStateMachine.HandleInput();
            
            _movementStateMachine.Update();
        }

        private void FixedUpdate()
        {
            _movementStateMachine.PhysicsUpdate();
        }
    }
}
