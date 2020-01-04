using System;

namespace DonEnglandArt
{
    public static class UpdateCaller
    {
        public static event Action Update;
        
        public static void SendUpdate()
        {
            Update?.Invoke();
        }

        public static void Reset()
        {
            Update = null;
        }
    }

    public sealed class UpdateManager
    {
        private UpdateManager() { }
        private static UpdateManager _instance = null;
        public static UpdateManager Instance => _instance ?? (_instance = new UpdateManager());

        public event Action Update;

        public void SendUpdate()
        {
            Update?.Invoke();
        }

        public void Reset()
        {
            Update = null;
        }
    }
}