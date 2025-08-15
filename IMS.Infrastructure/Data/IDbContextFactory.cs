using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Data
{
    public interface IDbContextFactory
    {
        IDbConnection CreateOpenConnection();

    }
}
