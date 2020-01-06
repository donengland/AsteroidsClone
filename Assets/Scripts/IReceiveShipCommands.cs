namespace DonEnglandArt.Asteroids
{
    public interface IReceiveShipCommands
    {
        void FireOn();
        void FireOff();
        void ThrustOn();
        void ThrustOff();
        void TurnLeftBegin();
        void TurnLeftEnd();
        void TurnRightBegin();
        void TurnRightEnd();
    }
}