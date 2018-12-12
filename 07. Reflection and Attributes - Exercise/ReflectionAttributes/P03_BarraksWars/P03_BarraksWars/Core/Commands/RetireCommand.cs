namespace _03BarracksFactory.Core.Commands
{
    using Attributes;
    using Contracts;

    public class RetireCommand : Command
    {
        [Inject]
        private IRepository repository;

        public RetireCommand(string[] data) : base(data)
        {
        }

        public IRepository Repository
        {
            get { return this.repository; }
            private set { this.repository = value; }
        }

        public override string Execute()
        {
            string unitType = Data[1];
            string output = string.Empty;

            try
            {
                this.Repository.RemoveUnit(unitType);
                output = unitType + " retired!";
            }
            catch (System.Exception ex)
            {
                output = ex.Message;
            }

            return output;
        }
    }
}
