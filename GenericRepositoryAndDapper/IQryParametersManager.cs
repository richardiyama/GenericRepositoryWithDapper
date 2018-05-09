using System.Collections.Generic;

namespace GenericRepositoryAndDapper
{
    public interface IQryParametersManager
    {
        Dictionary<string, object> GetParametersDictionary(object parameters);
        string GenerateStringQry(string qry, Dictionary<string, object> parameters);
    }
}