using AlgorithemFinal.Models;
using AlgorithemFinal.Models.Requests;
using AlgorithemFinal.Models.Response;
using AlgorithemFinal.Utiles;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithemFinal.Services
{
    public interface IUserService
    {
        AuthResponse Authenticate(AuthRequest model);

        //IEnumerable<AuthUser> GetAll();

        User GetById(int id);
    }

    public class UserService : IUserService
    {
        private readonly ComponentConfig _config;
        private readonly AfDbContext _dbContext;

        public UserService(IOptions<ComponentConfig> componentConfig, AfDbContext soNetContext)
        {
            this._config = componentConfig.Value;
            this._dbContext = soNetContext;
        }

        public AuthResponse Authenticate(AuthRequest model)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Code == model.Code && x.Password == model.Password);
            //var user = _users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = GenerateJwtToken(user);

            return new AuthResponse() { User = user, Token = token, ExpireAt = DateTime.UtcNow.AddDays(7) };
        }

        //public IEnumerable<AuthUser> GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        public User GetById(int id)
        {
            return _dbContext.Users.FirstOrDefault(x => x.Id == id);
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.Jwt.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddHours(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }

}
