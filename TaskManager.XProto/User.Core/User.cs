using Paylater.TestTask.TaskManager.User.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Proto.Common.AppAccessors;
using X.Proto.Common.Entities;
using X.Proto.Db.Component.Dml;

namespace Paylater.TestTask.TaskManager.User.Core
{
    public class User : XServiceAccessor, IUser
    {
        private readonly XDmlComponent _dmlComponent;

        public User( XDmlComponent pDmlComponent )
        {
            _dmlComponent = pDmlComponent;
        }


        public async Task<XData> CreateAsync( XData pUser )
        {
            return await _dmlComponent.Execute( "InsertUser", pUser );
        }

        public async Task<XData> GetUserListAsync()
        {
            return await _dmlComponent.Execute( "SelectUserList" );
        }
    }
}
