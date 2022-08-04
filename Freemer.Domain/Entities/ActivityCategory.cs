using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freemer.Domain.Entities
{
    public class ActivityCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DefaultValue(0)]
        public int ParentId { get; set; }

        public string OtherInfo { get; set; }


        //public ContentCategory()
        //{
        //    this.DataContainer = new List<DataContainer>();
        //}
        //public ContentCategory(int id, string name) => (Id, Name) = (id, name);
        //public ICollection<DataContainer> DataContainer { get; set; }
    }
}
