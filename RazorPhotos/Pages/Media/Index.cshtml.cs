using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPhotos.Models;
using ServiceReferencePhotos;

namespace RazorPhotos.Pages.Media
{
    public class IndexModel : PageModel
    {
        public IList<MediaDTO> Media { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public int resultNumber { get; set; }
        public IndexModel()
        {
            Media = new List<MediaDTO>();
            resultNumber = 0;
        }
        public async Task OnGetAsync()
        {
            MediaTagsClient mtc = new MediaTagsClient();
            if (!string.IsNullOrEmpty(SearchString))
            {
                var tagsResult = await mtc.QueryTagsAsync(SearchString);

                HashSet<int> mediaIds = new HashSet<int>(tagsResult);

                foreach (int mediaId in mediaIds)
                {
                    var m = await mtc.GetMediaAsync(mediaId);
                    IList<TagDTO> Tags = new List<TagDTO>();
                    MediaDTO md = new MediaDTO();
                    md.Id = m.Id;
                    md.Creation_Date = m.Creation_Date;
                    md.Description = m.Description;
                    md.Path = m.Path;
                    Media.Add(md);
                }
                resultNumber = Media.Count;
            }
        }
    }
}