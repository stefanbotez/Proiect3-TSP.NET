using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPhotos.Models;
using ServiceReferencePhotos;

namespace RazorPhotos.Pages.Tags
{
    public class IndexModel : PageModel
    {
        MediaTagsClient mtc = new MediaTagsClient();
        public List<TagDTO> Tags { get; set; }

        public IndexModel()
        {
            Tags = new List<TagDTO>();
        }
        public async Task OnGetAsync()
        {
            var tags = await mtc.GetAllTagsAsync();
            foreach (var item in tags)
            {
                TagDTO td = new TagDTO();
                td.Name = item.Name;
                Tags.Add(td);
            }
            var unique_items = new HashSet<TagDTO>(Tags);
            Tags = unique_items.ToList<TagDTO>();
            Tags.Sort(delegate (TagDTO t1, TagDTO t2) { return t1.Name.CompareTo(t2.Name); });
        }
    }
}