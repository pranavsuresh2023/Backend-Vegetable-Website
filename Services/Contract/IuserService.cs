using AssignmentProject.Models;
using AssignmentProject.Utilities;


namespace AssignmentProject.Services.Contract
{
    public interface IuserService
    {
        public ResponseUser AddData(ResponseUser responseUser);
        public string Verify(ResponseUser responseUser);
        public string CreateToken(UserDetail login);
    }
}

