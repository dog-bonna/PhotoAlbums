using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;

using PhotoAlbums.Models;

namespace PhotoAlbums.Controllers
{
    public class UserController : Controller
    {

        private static HttpClient client;
        public UserController()
        {
            /* TODO: Modularize Client code instead of repeating it */
            client = new HttpClient();
            client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );
        }

        public async Task<IActionResult> Index(int? id)
        {
            if (id == null) {
                return NotFound();
            }
            User user = null;
            var userResp = await client.GetAsync($"users/{id}");

            if (userResp.IsSuccessStatusCode)
            {
                user = await userResp.Content.ReadAsAsync<User>();
            }
            else {
                return NotFound();
            }

            var userPostsResp = await client.GetAsync($"users/{id}/posts");

            if (userPostsResp.IsSuccessStatusCode) {
                user.Posts = await userPostsResp.Content.ReadAsAsync<List<Post>>();
            }

            return View(user);
        }
    }
}