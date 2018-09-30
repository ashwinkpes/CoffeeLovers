namespace CoffeeLovers.IBusinessLogic
{
    public interface ISecurityService
    {
        string GetSha256Hash(string input);
    }
}