using System.Collections.Generic;

namespace TaskSchedule.Areas.Admin.Models
{
    public class AssignPersonnelViewModel
    {


        public int IsId { get; set; }

        public List<int> personnelId { get; set; }
    }
}