using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data.Common;

namespace CNPJ.Data.Extension
{
    public static class EFExtensions
    {
        public static DbTransaction GetTransaction(this IDbContextTransaction source)
        {
            if (source == null)
                return null;

            return (source as IInfrastructure<DbTransaction>).Instance;
        }
    }
}
