using Paylater.TestTask.TaskManager.Core.Users.Entities;
using Paylater.TestTask.TaskManager.WebApp.Dtos;


namespace Paylater.TestTask.TaskManager.WebApp.Mapping
{

    public static class UserMapping
    {
        public static UserDto UserEntityToUserDto( User user )
          {
            return new UserDto( user.Id, user.Name, user.Tasks );
        }

        public static User UserDtoToUserEntity( UserDto userDto ) 
        {
            return new User() { Name = userDto.Name };
        }

        //public static IEnumerable<User> UserDtoListToUserEntity( List<UserDto> userDtoList )
        //{
        //    var result = userDtoList.Select( e => new User() { Name = e.Name } );

        //    return result;
        //}
    }
}
