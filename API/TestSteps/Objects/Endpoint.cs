using TechTalk.SpecFlow;

namespace API.TestSteps.Objects
{
    public abstract class Endpoint
    {
        public string Url { get; set; }
        public string FilePath { get; set; }
        public Table DynamicFields = new Table("Attribute", "Type", "Value");

        public abstract Endpoint CreateEndpoint();
    }
}
