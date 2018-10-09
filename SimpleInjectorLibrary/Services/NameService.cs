using System;
using System.Collections.Generic;
using System.Text;
using SimpleInjectorLibrary.Models;

namespace SimpleInjectorLibrary.Services
{
    public interface INameService
    {
        bool SetName(string name);
        bool SetId(string id);
        UserModel GetUser(string id);
    }
    public class NameService : INameService
    {
        public UserModel User { get; set; }

        public NameService()
        {
            User = new UserModel();
        }

        public bool SetName(string name)
        {
            if (name == null) return false;
            User.Name = name;
            return true;

        }

        public bool SetId(string id)
        {
            if (id == null) return false;
            User.Id = id;
            return true;
        }

        public UserModel GetUser(string id)
        {
            return User;
        }

        
    }
}
