using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace PhotoAlbums.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }

        [DataType(DataType.Url)]
        public string Website { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        public Addr Address { get; set; }

        public Company Company { get; set; }

        public List<Post> Posts { get; set; }
    }
}