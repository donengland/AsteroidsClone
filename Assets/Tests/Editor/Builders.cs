namespace Tests
{
    public static class A
    {
        public static ShipBuilder Ship => new ShipBuilder();
        public static ThrusterBuilder Thruster => new ThrusterBuilder();
    }

    public static class An
    {
        public static AsteroidBuilder Asteroid => new AsteroidBuilder();
    }
}