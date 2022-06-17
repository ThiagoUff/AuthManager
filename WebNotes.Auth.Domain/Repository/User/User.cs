using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebNotes.Auth.Domain.Repository.User
{
    public class User
    {
        public string Id { get; set; }

        [BsonElement("Username")]
        public string Username { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public int LoginCount { get; set; }
    }
}
