using UnityEngine;
using UnityEngine.InputSystem;

namespace DonEnglandArt.Asteroids
{
    [RequireComponent(typeof(PlayerInput))]
    public class MonoShip : MonoBehaviour, IReceiveShipCommands
    {
        private UserInput _input;
        private Ship _ship;
        private Bounds _bounds;

        private void Awake()
        {
            _ship = new Ship(UpdateManager.Instance, transform.position, Vector3.up);
            _ship.SetTransform(transform);
            _bounds = AsteroidManager.Instance.GetBounds();
            var playerInput = GetComponent<PlayerInput>();
            _input = new UserInput(playerInput);
            _input.SetTarget(this);
        }

        private void Update()
        {
            WrapBounds2DSystem.ProcessMove(_ship as IWrapInBounds, _bounds);
        }

        public void FireOn()
        {
            Debug.Log($"FireOn");
        }

        public void FireOff()
        {
            Debug.Log($"FireOff");
        }

        public void ThrustOn()
        {
            _ship.ThrustOn();
        }

        public void ThrustOff()
        {
            _ship.ThrustOff();
        }

        public void TurnLeftBegin()
        {
            _ship.TurnLeftBegin();
        }

        public void TurnLeftEnd()
        {
            _ship.TurnLeftEnd();
        }

        public void TurnRightBegin()
        {
            _ship.TurnRightBegin();
        }

        public void TurnRightEnd()
        {
            _ship.TurnRightEnd();
        }
    }
}