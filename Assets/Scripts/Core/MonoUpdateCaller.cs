using UnityEngine;

namespace DonEnglandArt
{
    public class MonoUpdateCaller : MonoBehaviour
    {
        private void Update()
        {
            UpdateCaller.SendUpdate();
        }
    }
}