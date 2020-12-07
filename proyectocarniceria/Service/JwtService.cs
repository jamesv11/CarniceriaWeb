using Entidad;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using proyectocarniceria.Config;
using proyectocarniceria.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace proyectocarniceria.Service
{
    public class JwtService
    {
        private readonly AppSetting _appSettings;
        public JwtService(IOptions<AppSetting> appSettings)=> _appSettings = appSettings.Value;
        public LoginViewModel GenerateToken(Cliente cliente)
        {         
            // return null if user not found
            if (cliente == null) return null;
            var userResponse = new LoginViewModel() { Nombre = cliente.Persona.Nombre ,Apellido = cliente.Persona.Apellido, Correo = cliente.Persona.Correo, Rol = cliente.Persona.Rol};
            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, cliente.Persona.Nombre.ToString()),
                    new Claim(ClaimTypes.Email, cliente.Persona.Correo.ToString()),                  
                    new Claim(ClaimTypes.Role, cliente.Persona.Rol.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            userResponse.Token = tokenHandler.WriteToken(token);
            return userResponse;
        }


    }
}