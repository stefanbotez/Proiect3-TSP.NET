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

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + Name.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                TagDTO t = (TagDTO)obj;
                return (Name == t.Name) && (MediaId == t.MediaId);
            }
        }
    }
}
