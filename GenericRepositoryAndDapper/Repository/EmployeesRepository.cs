using GenericRepositoryAndDapper.Models;
using GenericRepositoryAndDapper.Models.ViewModel;
using System.Collections.Generic;
using System.Data;

namespace GenericRepositoryAndDapper.Controllers
{
    public class EmployeesRepository : DPGenericRepository<Employees>
    {
        public char Identified;
        public IDbConnection _conn;
       
        public EmployeesRepository(IDbConnection conn, char parameterIdentified = '@') : base(conn, parameterIdentified)
        {
            conn = _conn;
            parameterIdentified = Identified;
        }
      
    }
}