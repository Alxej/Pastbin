namespace Pastbin.API.Contracts
{
    public record UserResponse(
        Guid id,
        string userName,
        string name,
        string lastName,
        string surname
        );
}
