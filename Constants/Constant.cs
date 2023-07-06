using MinimalChatApplication.Model;

namespace MinimalChatApplication.Constants
{
    public class Constant
    {
        public const string Route = "api/[controller]/";
       
        public const string RegisterUser = "RegisterUser";
        public const string logs = "logs";

        public const string EnterMessageId = "Enter Message Id";
        public const string EnterLongValue = "Enter Long Value";
        public const string CouldNotFetchData = "Could not fetch employee data.";
        public const string MessageEditedSuccessfully = "Message edited successfully";
        public const string MessageDeletedSuccessfully = "Message deleted successfully";

        public const string RecordNotFound = "Record not found..";
        public const string CouldNotFetchDepartmentData = "Could not fetch department data.";
        public const string EnterDepartmentId = "Enter DepartmentId";
        public const string TheKeyDoesNotExist = "The key does not exist";
        public const string IncorrectRequest = "Incorrect Request";
        public const string TheKeyAlreadyExists = "The key already exists";
        public const string TheRecordAlreadyExists = "The Record already exists";
        public const string LoginSuccessful = "Login Successful";
        public const string LoginFailedDueToIncorrectCredentials = "Login failed due to incorrect credentials.";
        public const string UnauthorizedAccess = "Unauthorized Access";

        public const int InternalServerError = 500;
        public const string InternalServerErrorS = "Internal server error";
    }
}
