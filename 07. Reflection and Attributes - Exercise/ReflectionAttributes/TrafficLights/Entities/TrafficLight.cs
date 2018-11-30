namespace TrafficLights.Entities
{
    using Enums;
    using System;

    public class TrafficLight
    {
        private Signal signal;

        public TrafficLight(string signal)
        {
            Enum.TryParse<Signal>(signal, out this.signal);
        }

        public void ChangeSignal()
        {
            int currentSignal = (int)this.signal;

            currentSignal++;

            this.signal = (Signal)(currentSignal % Enum.GetNames(typeof(Signal)).Length);
        }
    }
}
