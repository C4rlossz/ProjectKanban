using Microsoft.EntityFrameworkCore;
using ProjectKanban.Data;
using ProjectKanban.Dto;
using ProjectKanban.Models;

namespace ProjectKanban.Services.Activity
{
    public class ActivityServices : IActivityInterface
    {
        private readonly AppDbContext _context;
        public ActivityServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ActivityModel> BackCard(int activityId)
        {
            try
            {
                var activity = await _context.Activity.FindAsync(activityId);

                activity.StatusId--;


                _context.Update(activity);
                await _context.SaveChangesAsync();

                return activity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ActivityModel>> BuscarAtividades()
        {
            try
            {
                var activity = await _context.Activity.Include(x => x.Status).ToListAsync();

                return activity;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<StatusModel>> BuscarStatus()
        {
            try
            {
                var status = await _context.Status.ToListAsync();
                return status;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        // Teste de commit testando

    


        public async Task<ActivityModel> CadastrarAtividade(ActivityRegisterDTO activityRegisterDTO)
        {
            try
            {
                Random rand = new Random();

                var activity = new ActivityModel()
                {
                    Title = activityRegisterDTO.Title,
                    Description = activityRegisterDTO.Description,
                    StatusId = activityRegisterDTO.StatusId,
                    Registration = rand.Next(1000, 1000000)
                };

                _context.Activity.Add(activity);
                await _context.SaveChangesAsync();

                return activity;

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ActivityModel> Deletar(int activityId)
        {
            try
            {
                var activity = await _context.Activity.FindAsync(activityId);

                _context.Remove(activity);
                await _context.SaveChangesAsync();

                return activity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ActivityModel> SwitchCard(int activityId)
        {
            try
            {
                var activity = await _context.Activity.FindAsync(activityId);

                activity.StatusId++;


                _context.Update(activity);
                await _context.SaveChangesAsync();

                return activity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
