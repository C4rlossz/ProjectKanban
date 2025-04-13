using ProjectKanban.Dto;
using ProjectKanban.Models;

namespace ProjectKanban.Services.Activity
{
    public interface IActivityInterface
    {
        Task<List<ActivityModel>> BuscarAtividades();
        Task<List<StatusModel>> BuscarStatus();
        Task<ActivityModel> CadastrarAtividade(ActivityRegisterDTO activityRegisterDTO);
        Task<ActivityModel> SwitchCard(int activityId);
        Task<ActivityModel> BackCard(int activityId);
        Task<ActivityModel> Deletar(int activityId);
    }
}
