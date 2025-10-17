using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Proto.Common.Entities;

namespace Paylater.TestTask.TaskManager.User.Api
{
    public interface IUser
    {
        Task<XData> CreateAsync( XData pUser );

        Task<XData> GetUserListAsync();
    }
}
