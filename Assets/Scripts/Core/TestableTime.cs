using UnityEngine;

namespace DonEnglandArt
{
    public static class TestableTime
    {
        private static float _testTime;
        public static float deltaTime => Time.deltaTime + _testTime;
        public static float fixedDeltaTime => Time.fixedDeltaTime + _testTime;

        public static void AdvanceSeconds(float seconds)
        {
            _testTime += seconds;
        }

        public static void ResetTime()
        {
            _testTime = 0f;
        }
    }
}