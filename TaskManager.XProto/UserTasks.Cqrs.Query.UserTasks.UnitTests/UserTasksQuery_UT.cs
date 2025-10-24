using Moq;
using Paylater.TestTask.TaskManager.UserTasks.Cqrs.Query.Infrastructure.Repository.UserTasks;
using Paylater.TestTask.TaskManager.UserTasks.Cqrs.Query.Infrastructure.Service.User;
using Paylater.TestTask.TaskManager.UserTasks.Cqrs.Query.UserTasks.Api;
using Paylater.TestTask.TaskManager.UserTasks.Cqrs.Query.UserTasks.Core;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.Proto.Common.Entities;

namespace UserTasks.Cqrs.Query.UserTasks.UnitTests
{
    public class UserTasksQuery_UT
    { 

        private Mock<IUserTasksRepository> _mockUserTasksRepository;
        private Mock<IUserService> _mockUserService;
        private UserTasksQuery _userTasksQuery;

        [SetUp]
        public void SetUp()
        {
            _mockUserTasksRepository = new Mock<IUserTasksRepository>();
            _mockUserService = new Mock<IUserService>();

            _userTasksQuery = new UserTasksQuery( _mockUserTasksRepository.Object, _mockUserService.Object );
        }

        [Test]
        public async Task GetUserTasks_JoinTasksWithUserName_OK()
        {
            // Arrange
            var x0 = new XData();
            x0.Fields.AddRange(  new List<string>(){ "F1", "F2", "F3" } );
            x0.Rows[0].AddRange( new List<object>(){ "v11", "v22", "v33" } );
            x0.Rows.Add( new List<object>() );
            x0.Rows[1].AddRange( new List<object>(){ "v21", "v22", "v23" } );
            var userTasksRepository_GetUserTasksAsync_Result = x0;

            var x1 = new XData();
            x1.Fields.Add( "name" );
            x1.Rows[0].Add( "XXX" );
            var userSevice_GetName_Result = x1;

            _mockUserTasksRepository.Setup( x => x.GetUserTasksAsync( It.IsAny<XData>())).ReturnsAsync( userTasksRepository_GetUserTasksAsync_Result );
            _mockUserService.Setup( x => x.GetName( It.IsAny<XData>() ) ).ReturnsAsync( userSevice_GetName_Result );

            // Act
            var result = await _userTasksQuery.GetUserTasksAsync( It.IsAny<XData>() );

            var s = result.Fields.Last();

            // Assert
            Assert.AreEqual( result.Fields.Count, 4 );
            Assert.AreEqual( result.Fields.Last() , "UserName" );
            Assert.AreEqual( result.Rows[0].Last(), "XXX" );
            Assert.AreEqual( result.Rows[1].Last(), "XXX" );

        }
    }
}