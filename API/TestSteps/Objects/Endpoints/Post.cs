namespace API.TestSteps.Objects.Endpoints
{
    internal class Post : Endpoint
    {
        public override Endpoint CreateEndpoint()
        {
            Url = "/posts";
            FilePath = "Post\\post_create.json";

            return this;
        }
    }
}
