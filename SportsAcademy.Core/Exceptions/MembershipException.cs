namespace SportsAcademy.Core.Exceptions
{
    public class MembershipException : ApplicationException
    {
        public MembershipException()
        {
                
        }

        public MembershipException(string errorMessage)
            : base(errorMessage)
        {

        }
    }
}
