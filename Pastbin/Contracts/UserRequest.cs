namespace Pastbin.API.Contracts
{
    public record UserRequest(
        string userName,
        string password,
        string name,
        string lastName,
        string surname
        );
}
