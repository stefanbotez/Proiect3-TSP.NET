using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace RazorPhotos.Models
{
    public class TagDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int MediaId { get; set; }
        [DataMember]

        public virtual MediaDTO Media { get; set; }
    }
}
