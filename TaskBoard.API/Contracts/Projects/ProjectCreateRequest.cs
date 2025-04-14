namespace TaskBoard.API.Contracts.Projects
{
    public record ProjectCreateRequest(Guid id, string name, string description, DateTime createdAt, DateTime updatedAt)
    {
    }
}
