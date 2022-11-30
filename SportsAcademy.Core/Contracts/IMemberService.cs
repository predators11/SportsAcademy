namespace SportsAcademy.Core.Contracts
{
    public interface IMemberService
    {
        Task<bool> ExistsById(string userId);

        Task<bool> UserWithPhoneNumberExists(string phoneNumber);
        
        Task<bool> UserHasBuys(string userId);

        Task Create(string firstName, string lastName, string userId, string phoneNumber);

        Task<int> GetMemberId(string userId);

        Task<bool> UserWithFirstNameExists(string firstName);

        Task<bool> UserWithLastNameExists(string lastName);
    }
}
