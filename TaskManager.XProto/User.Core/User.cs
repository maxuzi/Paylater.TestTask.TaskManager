using Paylater.TestTask.TaskManager.User.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Proto.Common.AppAccessors;
using X.Proto.Common.Entities;
using X.Proto.Common.Events;
using X.Proto.Db.Component.Dml;

namespace Paylater.TestTask.TaskManager.User.Core
{
    public class User : XServiceAccessor, IUser
    {
        private readonly IXDmlComponent _dmlComponent;

        public User( IXDmlComponent pDmlComponent )
        {
            _dmlComponent = pDmlComponent;
        }


        public virtual async Task<XData> CreateAsync( XData pUser )
        {
            return await _dmlComponent.Execute( "InsertUser", pUser );
        }

        public virtual async Task<XData> GetUserListAsync()
        {
            return await _dmlComponent.Execute( "SelectUserList" );
        }
    }
}
