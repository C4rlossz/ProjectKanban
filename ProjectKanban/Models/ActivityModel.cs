using System.Reflection.Metadata.Ecma335;

namespace ProjectKanban.Models
{
    public class ActivityModel
    {
        public int Id { get; set; }
        public int Registration { get; set; }
        public string Title { get; set; }
        public String Description { get; set; }
        public DateTime DateCriation { get; set; } = DateTime.Now;
        public int StatusId { get; set; }
        public StatusModel Status { get; set; }
    }
}
