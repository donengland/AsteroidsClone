using System;

namespace DonEnglandArt
{
    public interface IProvideUpdates
    {
        event Action Update;
    }
}