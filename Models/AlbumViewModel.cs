using PhotoAlbums.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace PhotoAlbums.Models
{
    public class AlbumViewModel
    {
        public List<Album> Albums { get; set; }
        public List<Album> DisplayedAlbums {
            get
            {
                return Albums.Skip(PageSize * (Page - 1)).Take(PageSize).ToList();
            }
        }
        public static int PageSize { get; set; }
        public int Page {get; set;}
        public int TotalCount {
            get {
                return Albums.Count;
            }
        }
        public int TotalPages {
            get
            {
                return (int) Math.Ceiling(TotalCount / (double)PageSize);
            }
        }

        public AlbumViewModel()
        {
            PageSize = 10;
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