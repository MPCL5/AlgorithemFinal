using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using AlgorithemFinal.Models;
using AlgorithemFinal.Models.Requests;
using AlgorithemFinal.Models.Response;
using AlgorithemFinal.Utiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

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
            _config = componentConfig.Value;
            _dbContext = soNetContext;
        }

        public AuthResponse Authenticate(AuthRequest model)
        {
            var user = _dbContext.Users
                .Include(user => user.Admin)
                .Include(user => user.Master)
                .Include(user => user.Student)
                .FirstOrDefault(x => x.Code == model.Code);

            // return null if user not found
            if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.Password)) return null;

            // authentication successful so generate jwt token
            var token = GenerateJwtToken(user);

            return new AuthResponse {User = user, Token = token, ExpireAt = DateTime.UtcNow.AddDays(7)};
        }

        //public IEnumerable<AuthUser> GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        public User GetById(int id)
        {
            return _dbContext.Users
                .Include(user => user.Admin)
                .Include(user => user.Master)
                .Include(user => user.Student)
                .FirstOrDefault(x => x.Id == id);
        }

        private string GenerateJwtToken(User user)
        {
            var userAdmin = user.Admin;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.Jwt.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {new Claim("id", user.Id.ToString())}),
                Expires = DateTime.UtcNow.AddHours(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}