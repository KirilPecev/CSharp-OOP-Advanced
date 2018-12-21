namespace FestivalManager.Entities.Instruments
{
    public class Drums : Instrument
    {
        private const int DefaultRepairAmount = 20;

        public Drums()
        {
        }

        protected override int RepairAmount => DefaultRepairAmount;
    }
}
