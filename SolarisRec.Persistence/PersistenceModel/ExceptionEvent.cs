namespace SolarisRec.Persistence.PersistenceModel
{
    public class ExceptionEvent
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public string CallStack { get; set; }
    }
}