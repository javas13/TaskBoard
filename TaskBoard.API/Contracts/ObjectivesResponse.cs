namespace TaskBoard.API.Contracts
{
    public record ObjectivesResponse(Guid id, string name, string description, string type)
    {
    }
}
