using RestSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MessagePublisher.Client.Services
{
    public class IconsService : IIconsService
    {
        public IEnumerable<Image> GetAll()
        {
            var images = new List<Image>();
            using (WebClient client = new WebClient())
            {
                var ex1 = client.DownloadData("http://ichef.bbci.co.uk/news/976/cpsprodpb/12787/production/_95455657_3312a880-230e-474c-b1d9-bb7c94f8b00e.jpg");
                var ex2 = client.DownloadData("https://cdn.vectoricons.net/wp-content/themes/checkout-child/images/me-as-icon-with-glass-transparent.png");
                using (var ms = new MemoryStream(ex1))
                {
                    images.Add(Image.FromStream(ms));
                }
                using (var ms = new MemoryStream(ex2))
                {
                    images.Add(Image.FromStream(ms));
                }
            }

            return images;
        }
    }
}
