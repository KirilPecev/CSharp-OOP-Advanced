namespace FestivalManager.Entities.Instruments
{
    public class Guitar : Instrument
    {
        private const int DefaultRepairAmount = 60;

        public Guitar()
        {
        }

        protected override int RepairAmount => DefaultRepairAmount;
    }
}
