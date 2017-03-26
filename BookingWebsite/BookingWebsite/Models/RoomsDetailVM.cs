using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingWebsite.Models
{
    public class RoomsDetailVM
    {
        public RoomsDetailVM(IHostingEnvironment env)
        {
            this.env = env;
        }

        private IHostingEnvironment env;
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Number { get; set; }
        public string Description { get; set; }
        public int? Price { get; set; }
        public int? Size { get; set; }
        public ICollection<String> Images
        {
            get
            {
                LinkedList<String> images = new LinkedList<string>();
                IDirectoryContents dirContent = env.WebRootFileProvider.GetDirectoryContents("images/rooms/" + Id);
                foreach (IFileInfo item in dirContent)
                {
                    images.AddLast(item.Name);
                }
                return images;
            }
        }
    }
}
