//using Carter;
//using SupportTick.Models;
//using SupportTick.Models.response;
//using SupportTick.Services;
//using static SupportTick.Models.request.Auth;
//using static System.Object;

//namespace EmpLine_server.Module;


//public class AuthModule : ICarterModule
//{
//    public void AddRoutes(IEndpointRouteBuilder routes)
//    {

//        routes.MapPost("/auth/login", async (LoginModel model, IAuthService authService, IUserService userService) =>
//        {

//            Console.WriteLine($"user login: email {model.Email} ");

//            User user = await userService.GetUserByEmailAsync(model.Email);

//            if (user == null)
//            {
//                Console.WriteLine("user is not register");
//                return Results.Unauthorized();
//            }

//            var token = authService.GenerateJwtToken(model.Email);

//            var userRes = new AuthResModel()
//            {

//                Id = user.UserId,
//                Name = user.FullName,
//                Email = user.Email
//            };

//            return Results.Ok(new { Token = token, User = userRes });


//        });


//        routes.MapPost("/auth/register", async (RegisterModel model, IUserService userService, IAuthService authService) =>
//        {

//            if (model == null)
//            {
//                return Results.Conflict("user is not valid");
//            }

//            var isExistUser = await userService.GetUserByEmailAsync(model.Email);

//            if (isExistUser != null)
//            {
//                return Results.Conflict("Email alredy exist");
//            }

//            var createdUser = await userService.CreateUserAsync(model);

//            if (createdUser == null)
//            {
//                return Results.Problem("Failed to create user", statusCode: 500);
//            }

//            var token = authService.GenerateJwtToken(model.Email);

//            var userRes = new AuthResModel()
//            {
//                Id = createdUser.UserId,
//                Name = createdUser.FullName,
//                Email = createdUser.Email
//            };

//            return Results.Ok(new { Token = token, User = userRes });

//        });
//    }

//}




