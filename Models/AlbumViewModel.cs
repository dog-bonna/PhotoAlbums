using PhotoAlbums.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace PhotoAlbums.Models
{
    public class AlbumViewModel
    {
        public List<Album> DisplayedAlbums { get; set; }
        public int PageSize { get; set; }
        public int Page {get; set;}
        public int TotalCount { get; set; }

        // public string SearchString { get; set; }

        public int TotalPages {
            get
            {
                return (int) Math.Ceiling(TotalCount / (double)PageSize);
            }
        }

        public bool HasPreviousPage {
            get {
                return (Page  > 1);
            }
        }

        public bool HasNextPage {
            get {
                return (Page < TotalPages);
            }
        }


    }
}