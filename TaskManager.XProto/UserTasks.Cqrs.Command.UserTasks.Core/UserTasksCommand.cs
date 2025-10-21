using Paylater.TestTask.TaskManager.UserTasks.Cqrs.Command.UserTasks.Api;
using Paylater.TestTask.TaskManager.UserTasks.Cqrs.Command.UserTasks.Core.StatusRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using X.Proto.Common.AppAccessors;
using X.Proto.Common.Entities;
using X.Proto.Db.Component.Dml;

namespace Paylater.TestTask.TaskManager.UserTasks.Cqrs.Command.UserTasks.Core
{
    public class UserTasksCommand : XServiceAccessor, IUserTasksCommand
    {
        private readonly IXDmlComponent      _dmlComponent;
        private readonly IUserTaskStatusRule _statusRules;

        public UserTasksCommand( IXDmlComponent pDmlComponent, IUserTaskStatusRule pStatusRules )
        {
            _dmlComponent = pDmlComponent;
            _statusRules  = pStatusRules;
        }

        public virtual async Task<XData> CreateAsync( XData pUserTask )
        {
            this.checkStatusRule( String.Empty );
            this.createHistoryField( ref pUserTask );

            return await _dmlComponent.Execute( "InsertUserTasks", pUserTask );
        }

        public virtual async Task<XData> UpdateStatusAsync( XData pUpdateStatusData )
        {
            pUpdateStatusData.SetValue( DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss.fff" ), "HistId" );

            return await _dmlComponent.Execute( "UpdateUserTasksStatus", pUpdateStatusData );
        }





        protected virtual void createHistoryField( ref XData rUserTask ) 
        {
            rUserTask.Fields.Add( "History" );

            var history = new { DateId = DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss.fff" ),
                Status = "NEW" };

            string res = JsonSerializer.Serialize( history );

            rUserTask.Rows[0].Add( $"[{res}] ");
        }

        protected virtual void checkStatusRule( string pHistory ) 
        {
            string result = _statusRules.Check( pHistory );

            if( "OK" != result )
            {
                throw new Exception( result );
            }
        }
        
    }
}
