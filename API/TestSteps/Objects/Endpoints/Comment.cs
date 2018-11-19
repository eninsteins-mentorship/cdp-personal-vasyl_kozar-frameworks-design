namespace API.TestSteps.Objects.Endpoints
{
    internal class Comment : Endpoint
    {
        public override Endpoint CreateEndpoint()
        {
            Url = "/comments";
            FilePath = "Comment\\comment_create.json";

            return this;
        }
    }
}
