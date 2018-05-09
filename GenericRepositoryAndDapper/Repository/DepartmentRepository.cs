using GenericRepositoryAndDapper.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace GenericRepositoryAndDapper.Repository
{
    public class DepartmentRepository : DPGenericRepository<Department>
    {
        public char Identified;
        public IDbConnection _conn;
        public DepartmentRepository(IDbConnection conn, char parameterIdentified = '@') : base(conn, parameterIdentified)
        {
            conn = _conn;
            parameterIdentified = Identified;
            
        }

    }
}