


using Paylater.TestTask.TaskManager.GatewayRestfullApi.Dtos;
using System.Text.Json;
using X.Proto.Common.Entities;

namespace Paylater.TestTask.TaskManager.GatewayRestfullApi.Mapping
{

    public static class UserTasksMapping
    {

        public static XData UserTaskDtoToXData( UserTasksDto pUserTasksDto )
        {
            var result = new XData();
            result.Fields = new List<string>() { "UserId", "DateId", "Title", "Description" };

            result.Rows[0].Add( pUserTasksDto.UserId.ToString( "yyyy-MM-dd HH:mm:ss.fff" ) );
            result.Rows[0].Add( pUserTasksDto.TaskId );
            result.Rows[0].Add( pUserTasksDto.Title );
            result.Rows[0].Add( pUserTasksDto.Description );

            return result;
        }

        public static XData UpdateStatusDtoToXData( DateTime pUserId, DateTime pTaskId, string pStatusCode ) 
        {
            var result = new XData();
            result.Fields = new List<string>() { "UserId", "TaskId", "HistId", "Status" };

            result.Rows[0].Add( pUserId.ToString( "yyyy-MM-dd HH:mm:ss.fff" ) );
            result.Rows[0].Add( pTaskId.ToString( "yyyy-MM-dd HH:mm:ss.fff" ) );
            result.Rows[0].Add( String.Empty );
            result.Rows[0].Add( pStatusCode );

            return result;
        }


        public static XData UserIdDtoToXData( DateTime pUserId )
        {
            var result = new XData();
            result.Fields = new List<string>() { "UserId" };

            result.Rows[0].Add( pUserId.ToString( "yyyy-MM-dd HH:mm:ss.fff" ) );
            

            return result;
        }

        public static List<UserTasksViewDto> JsonToUserTaskDto( JsonElement pBackendResult )
        {
            var result = new XData( pBackendResult ).Rows.Select( e => new UserTasksViewDto( e[6].ToString()
                                                                                            ,Convert.ToDateTime(e[3]).ToString( "yyMMddHHmmssfff" )
                                                                                            ,e[1].ToString()
                                                                                            ,e[2].ToString()
                                                                                            ,Convert.ToDateTime(e[3]).ToString( "yyyy-MM-dd HH:mm:ss.fff" )
                                                                                            ,Convert.ToDateTime(e[4]).ToString( "yyyy-MM-dd HH:mm:ss.fff" )
                                                                                            ,e[5].ToString()
                                                                                           )
                                                                ).ToList();

            return result;
        }

    }
}
