namespace FestivalManager.Entities.Instruments
{
    public class Microphone : Instrument
    {
        private const int DefaultRepairAmount = 80;

        public Microphone()
        {
        }

        protected override int RepairAmount => DefaultRepairAmount;
    }
}
