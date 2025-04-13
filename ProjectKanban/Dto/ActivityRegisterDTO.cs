using System.ComponentModel.DataAnnotations;

namespace ProjectKanban.Dto
{
    public class ActivityRegisterDTO
    {
        [Required(ErrorMessage = "Digite o titulo")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Digite a Descricao")]

        public String Description { get; set; }
        public DateTime DateCriation { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Selecione um status")]

        public int StatusId { get; set; }
    }
}
