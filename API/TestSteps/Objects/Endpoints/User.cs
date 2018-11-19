namespace API.TestSteps.Objects.Endpoints
{
    internal class User : Endpoint
    {
        public override Endpoint CreateEndpoint()
        {
            Url = "/users";
            FilePath = "User\\user_create.json";

            return this;
        }
    }
}
