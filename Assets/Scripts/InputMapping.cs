using System.Collections.Generic;
using UnityEngine.InputSystem;

namespace DonEnglandArt.Asteroids
{
    public class InputMapping
    {
        private Dictionary<string, InputAction> _actions;
        private readonly PlayerInput _playerInput;

        public InputMapping(PlayerInput playerInput)
        {
            _playerInput = playerInput;
            Register();
        }
        
        public void Register()
        {
            foreach (var entry in _actions)
            {
                _actions[entry.Key] = _playerInput.actions.FindAction(entry.Key);
            }
        }

        public InputAction GetAction(string name)
        {
            return _actions[name];
        }
    }
}