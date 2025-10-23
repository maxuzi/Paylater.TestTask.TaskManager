using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Security.Principal;
using System.Text.Encodings.Web;

namespace Paylater.TestTask.TaskManager.GatewayRestfullApi.Authentication
{
    public class CustomAuthenticationHandler : AuthenticationHandler<CustomAuthenticationSchemeOptions>
    {

        public CustomAuthenticationHandler( IOptionsMonitor<CustomAuthenticationSchemeOptions> options
                                             ,ILoggerFactory l
                                             ,UrlEncoder encoder
        ) : base( options, l, encoder )
        {
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            try
            {
                var tokenHeader = Request.Headers["Authorization"];

                if( tokenHeader.Count == 0)
                {
                    return AuthenticateResult.Fail( "No Authorization header" );
                }

                if( tokenHeader.Count > 1)
                {
                    return AuthenticateResult.Fail( "Only one Authorization header is allowed" );
                }

                if(String.IsNullOrEmpty( tokenHeader.First() )) 
                {
                    return AuthenticateResult.Fail( "Authorization header is empty" );
                }

                var token = tokenHeader.First().Remove(0,7);


       
                if( token !=  await getToken() ) 
                {
                    return AuthenticateResult.Fail( "Wrong token (tokens are not equel)" );
                }

                var claims = new List<Claim> { new( ClaimTypes.Name           ,"admin" )
                                              ,new( ClaimTypes.NameIdentifier ,"48" )
                                             };

                var identity  = new ClaimsIdentity( claims, Scheme.Name );
                var principal = new ClaimsPrincipal( identity );
                var ticket    = new AuthenticationTicket( principal, Scheme.Name );

                return AuthenticateResult.Success( ticket );
            }
            catch( Exception ex )
            {
                Logger.LogError( ex, String.Empty );
                return AuthenticateResult.Fail( "Wrong User" );
            }


        }

        private async Task<string> getToken() 
        {
            await Task.Delay( 1 );

            return "123";
        }
    }
}
