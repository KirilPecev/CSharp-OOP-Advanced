namespace TrafficLights
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using TrafficLights.Entities;

    class Program
    {
        static void Main(string[] args)
        {
            string[] trafficLightsSignals = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());

            TrafficLight[] trafficLights = new TrafficLight[trafficLightsSignals.Length];

            for (int i = 0; i < trafficLights.Length; i++)
            {
                trafficLights[i] = (TrafficLight)Activator.CreateInstance(typeof(TrafficLight), new object[] { trafficLightsSignals[i] });
            }


            for (int i = 0; i < n; i++)
            {
                List<string> result = new List<string>();

                foreach (var signal in trafficLights)
                {
                    signal.ChangeSignal();
                    FieldInfo field = typeof(TrafficLight).GetField("signal", BindingFlags.Instance | BindingFlags.NonPublic);
                    result.Add(field.GetValue(signal).ToString());
                }

                Console.WriteLine(string.Join(" ", result));
            }
        }
    }
}
