using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ImageUploadDemo.Pages
{
    public class IndexModel : PageModel
    {

        public IndexModel(IHostingEnvironment hostInformation)
        {
            this.HostInformation = hostInformation;
        }

        public void OnGet()
        {

        }

        [BindProperty]
        public IFormFile UploadFile { get; set; }
        public IHostingEnvironment HostInformation { get; }

        public async Task OnPost()
        {

            // For more information check the docs at:  https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads?view=aspnetcore-2.2

            using (var newFile = new FileStream(Path.Combine(HostInformation.WebRootPath, @"images", UploadFile.FileName), FileMode.CreateNew))
            {
                await UploadFile.CopyToAsync(newFile);
            }


        }

    }
}
