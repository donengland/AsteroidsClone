using UnityEngine;
using UnityEngine.InputSystem;

namespace DonEnglandArt.Asteroids
{
    public class UserInput
    {
        [SerializeField] private IReceiveShipCommands _target;
        private AsteroidsActions _actions;

        public UserInput(PlayerInput playerInput)
        {
            var playerInput1 = playerInput;
            var turnLeft = playerInput1.actions.FindAction("TurnLeft");
            var turnRight = playerInput1.actions.FindAction("TurnRight");
            var thrust = playerInput1.actions.FindAction("Thrust");
            var fire = playerInput1.actions.FindAction("Fire");
            turnLeft.started += OnTurnLeftBegin;
            turnLeft.canceled += OnTurnLeftEnd;
            turnRight.started += OnTurnRightBegin;
            turnRight.canceled += OnTurnRightEnd;
            thrust.started += OnThrustOn;
            thrust.canceled += OnThrustOff;
            fire.started += OnFireOn;
            fire.canceled += OnFireOff;
        }

        public void SetTarget(IReceiveShipCommands target)
        {
            _target = target;
        }

        private void OnFireOff(InputAction.CallbackContext obj)
        {
            _target.FireOff();
        }

        private void OnFireOn(InputAction.CallbackContext obj)
        {
            _target.FireOn();
        }

        private void OnThrustOff(InputAction.CallbackContext obj)
        {
            _target?.ThrustOff();
        }

        private void OnThrustOn(InputAction.CallbackContext obj)
        {
            _target?.ThrustOn();
        }

        private void OnTurnRightEnd(InputAction.CallbackContext obj)
        {
            _target?.TurnRightEnd();
        }

        private void OnTurnRightBegin(InputAction.CallbackContext obj)
        {
            _target?.TurnRightBegin();
        }

        private void OnTurnLeftEnd(InputAction.CallbackContext obj)
        {
            _target?.TurnLeftEnd();
        }

        private void OnTurnLeftBegin(InputAction.CallbackContext obj)
        {
            _target?.TurnLeftBegin();
        }
    }
}