using System.ComponentModel.DataAnnotations.Schema;

namespace ChildCentre.Slynchogled.Data.Models
{
    public class ActiveChild
    {
        public int ID { get; set; }

        public int ChildNumber { get; set; }

        public DateTime SignedIn { get; set; }

        public int ChildId { get; set; }

        [ForeignKey(nameof(ChildId))]
        public Child Child { get; set; }

        public bool WithParent { get; set; }
    }
}