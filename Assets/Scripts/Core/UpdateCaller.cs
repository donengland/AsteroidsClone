﻿using System;

namespace DonEnglandArt
{
    public class UpdateCaller : IProvideUpdates
    {
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