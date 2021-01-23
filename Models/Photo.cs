using System;
using PhotoAlbums.Models;

namespace PhotoAlbums.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }

        public int AlbumId { get; set; }

        public string ThumbnailURL { get; set; }
    }
}