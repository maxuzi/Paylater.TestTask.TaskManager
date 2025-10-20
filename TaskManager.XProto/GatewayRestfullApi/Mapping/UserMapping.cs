


using Paylater.TestTask.TaskManager.GatewayRestfullApi.Dtos;
using System.Text.Json;
using X.Proto.Common.Entities;

namespace Paylater.TestTask.TaskManager.GatewayRestfullApi.Mapping
{

    public static class UserMapping
    {
        public static List<UserDto> JsonToUserDto( JsonElement pBackendResult )
          {
            var result = new XData( pBackendResult ).Rows.Select( e => new UserDto( Convert.ToDateTime( e[0] )
                                                                 ,e[1].ToString() ) 
                                                                ).ToList();

            return result;
        }

        public static XData UserDtoToXData( UserDto pUser ) 
        {
            var result = new XData();
            result.Fields = new List<string>() { "DateId", "Name" };

            result.Rows[0].Add( pUser.DateId );
            result.Rows[0].Add( pUser.Name );

            return result;
        }
    }
}
