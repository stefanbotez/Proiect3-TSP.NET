using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPhotos.Models;
using ServiceReferencePhotos;

namespace RazorPhotos.Pages.Media
{
    public class DetailsModel : PageModel
    {
        MediaTagsClient mtc = new MediaTagsClient();
        public MediaDTO Media { get; set; }

        public DetailsModel()
        {
            Media = new MediaDTO();
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            int mediaId = (id == null ? default(int) : (int)(id));
            var m = await mtc.GetMediaAsync(mediaId);
            m = await mtc.GetMediaByPathAsync(m.Path);
            if (m == null)
            {
                return NotFound();
            }
            IList<TagDTO> Tags = new List<TagDTO>();
            Media.Creation_Date = m.Creation_Date;
            Media.Description = m.Description;
            Media.Path = m.Path;
            foreach (var item in m.Tags)
            {
                TagDTO td = new TagDTO();
                td.Name = item.Name;
                Tags.Add(td);
            }
            Media.Tags = Tags;
            return Page();
        }
    }
}