namespace API.TestSteps.Objects.Endpoints
{
    internal class Todo : Endpoint
    {
        public override Endpoint CreateEndpoint()
        {
            Url = "/todos";
            FilePath = "Todo\\todo_create.json";

            return this;
        }
    }
}
