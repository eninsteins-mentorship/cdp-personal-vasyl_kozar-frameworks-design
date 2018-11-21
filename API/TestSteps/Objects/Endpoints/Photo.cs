namespace API.TestSteps.Objects.Endpoints
{
    internal class Photo : Endpoint
    {
        public override Endpoint CreateEndpoint()
        {
            Url = "/photos";
            FilePath = "Photo\\photo_create.json";

            return this;
        }
    }
}
