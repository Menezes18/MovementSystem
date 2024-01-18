using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MenezesMovementSystem
{
    [RequireComponent(typeof(PlayerInput))] // agora quando adiciona o script para o player(gameobject)  ele sempre adicionar o player input
    public class Player : MonoBehaviour
    {
        [field:Header("Referencias")]
        [field:SerializeField] public PlayerSO Data { get; private set; }
        [field: Header("Collisions")]
        [field:SerializeField] public  CapsuleColliderUtility ColliderUtility { get; private set; }
        [field: SerializeField] public PlayerLayerData LayerData { get; private set; }
        
        public Rigidbody Rigidbody { get; private set; }
        public Transform MainCameraTransform { get; private set; }
        public PlayerInput Input { get; private set; }
        private PlayerMovementStateMachine _movementStateMachine; //chamando a ref do state machine para passar os parametros 


        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
            Input = GetComponent<PlayerInput>(); // 
            ColliderUtility.Initialize(gameObject);
            ColliderUtility.CalculateCapsuleColliderDimensions();
            MainCameraTransform = Camera.main.transform;
            _movementStateMachine = new PlayerMovementStateMachine(this);
        }

        private void OnValidate()
        {
            ColliderUtility.Initialize(gameObject);
            ColliderUtility.CalculateCapsuleColliderDimensions();
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
