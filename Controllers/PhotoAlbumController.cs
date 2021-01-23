using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhotoAlbums.Models;

namespace PhotoAlbums.Controllers
{
    public class PhotoAlbumController : Controller
    {
        public PhotoAlbumController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );
        }
        private static HttpClient client;
        private static int PageSize = 10;

        // GET: PhotoAlbum
        public async Task<IActionResult> Index(int page = 1)
        {
            IEnumerable<Album> albums = null;
            IEnumerable<User> users = null;

            HttpResponseMessage albumResp =  await client.GetAsync("albums");
            HttpResponseMessage userResp =  await client.GetAsync("users");
            if (albumResp.IsSuccessStatusCode)
            {
                albums = (await albumResp.Content.ReadAsAsync<IEnumerable<Album>>());
            }
            if (userResp.IsSuccessStatusCode)
            {
                users = await userResp.Content.ReadAsAsync<IEnumerable<User>>();
            }


            var joinedData = from album in albums
                join user in users on album.UserId equals user.Id
                select new {album, user};

            await Task.WhenAll(joinedData.Select(async item => {
                item.album.User = item.user;
                IEnumerable<Photo> photos = null;
                HttpResponseMessage photoResp = await client.GetAsync($"albums/{item.album.Id}/photos");
                if (photoResp.IsSuccessStatusCode)
                {
                    photos = photoResp.Content.ReadAsAsync<IEnumerable<Photo>>().Result;
                }
                item.album.ThumbnailURL = photos.First<Photo>().ThumbnailURL;
            }));

            var albumVM = new AlbumViewModel
            {
                Albums = albums.ToList(),
                Page = page
            };

            return View(albumVM);
        }
    }
}