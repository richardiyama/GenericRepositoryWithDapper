using System.Collections.Generic;

namespace GenericRepositoryAndDapper
{
    public interface IPKExtractor
    {
        IEnumerable<object> ExtractPKInObjectEnumerable(object pk);
    }
}