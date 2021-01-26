using System;
using System.Collections.Generic;
using System.Net.Http;

using PhotoAlbums.Models;

namespace PhotoAlbums.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }

        public string ThumbnailURL { get; set; }
        public List<Photo> Photos { get; set; }
    }
}