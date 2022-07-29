using VRage.Game;

namespace ExtendedSurvival
{

    public static class WeatherConstants
    {

        public const float SPACE_TEMPERATURE = -270;
        public const float PRESURIZED_TEMPERATURE = 25;

        public static MyTemperatureLevel TemperatureToLevel(float temperature)
        {
            if (temperature <= 0)
                return MyTemperatureLevel.ExtremeFreeze;
            if (temperature <= 10)
                return MyTemperatureLevel.Freeze;
            if (temperature <= 35)
                return MyTemperatureLevel.Cozy;
            return temperature <= 55 ? MyTemperatureLevel.Hot : MyTemperatureLevel.ExtremeHot;
        }

        public enum WeatherEffectsLevel
        {

            Light = 0,
            Heavy = 1

        }

        public enum WeatherEffects
        {

            None = 0,
            Rain = 1,
            Thunderstorm = 2

        }

        public enum EnvironmentDetector
        {

            None = 0,
            Atmosphere = 1,
            ShipOrStation = 2,
            Space = 3,
            Underwater = 4

        }

    }

}