using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace RazorPhotos.Models
{
    public class MediaDTO
    {
        public MediaDTO()
        {
            this.IsDeleted = false;
            this.Tags = new HashSet<TagDTO>();
        }
        [DataMember]
        public int Id { get; set; }
        [Display(Name = "Image")]
        [DataMember]
        public string Path { get; set; }
        [Display(Name = "Creation Date")]
        [DataMember]
        public System.DateTime Creation_Date { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public virtual ICollection<TagDTO> Tags { get; set; }
    }
}
