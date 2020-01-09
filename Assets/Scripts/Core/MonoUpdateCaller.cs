using System;
using UnityEngine;

namespace DonEnglandArt
{
    public class MonoUpdateCaller : MonoBehaviour
    {
        private UpdateManager _updateManager;
        
        private void Awake()
        {
            _updateManager = UpdateManager.Instance;
        }

        private void Update()
        {
            _updateManager.SendUpdate();
        }
    }
}