namespace API.TestSteps.Objects.Endpoints
{
    internal class Album : Endpoint
    {
        public override Endpoint CreateEndpoint()
        {
            Url = "/albums";
            FilePath = "Album\\album_create.json";

            return this;
        }
    }
}
