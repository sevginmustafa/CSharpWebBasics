using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyFirstMvcApp.Data
{
    public class User:UserIdentity
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Cards = new HashSet<UserCard>();
        }

        public ICollection<UserCard> Cards { get; set; }
    }
}
