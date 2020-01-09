using System;

namespace DonEnglandArt
{
    public sealed class UpdateManager : IProvideUpdates
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