using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace StudentSaver.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<string> FilesInFolder = new List<string>();
        public string Specializare;
        public string An;
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
        public void OnPost()
        {
            Specializare = Request.Form["Specializare"];
            An = Request.Form["An"];
            GetFilesInFolder(Specializare,An);

        }
        public void GetFilesInFolder(string spec, string an) {
            string[] filePaths =Directory.GetFiles("wwwroot/Cursuri/" + spec + "/" + an + "/");
            foreach (string filepath in filePaths)
            {
                FilesInFolder.Add(new string(Path.GetFileName(filepath).ToString()));
            }
        }
    }
}
