using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Api_Template.Utils;

namespace Api_Template.Models.Template
{
    public partial class Usuario
    {
        public Usuario()
        {
            if (Id_usuario == Guid.Empty) Id_usuario = Guid.NewGuid();
            if (string.IsNullOrEmpty(Salt)) Salt = CryptographyService.GetSalt();
        }
    }
    public partial class Permiso
    {
        public Permiso()
        {
            if (Id_permiso == Guid.Empty) Id_permiso = Guid.NewGuid();
        }
    }
    public partial class Token
    {
        public Token()
        {
            if (Id_token == Guid.Empty) Id_token = Guid.NewGuid();
            if (string.IsNullOrEmpty(Salt)) Salt = CryptographyService.GetSalt();
        }
    }
}