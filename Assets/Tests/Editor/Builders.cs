namespace Tests
{
    public static class A
    {
        public static ShipBuilder Ship => new ShipBuilder();
        public static FloatAcceleratorBuilder FloatAccelerator => new FloatAcceleratorBuilder();
        public static SteerableDirectionBuilder SteerableDirection => new SteerableDirectionBuilder();
    }

    public static class An
    {
        public static AsteroidBuilder Asteroid => new AsteroidBuilder();
    }
}