﻿using BreweryMaster.API.Helpers.User;
using BreweryMaster.API.Mappers;
using BreweryMaster.API.Models.User;
using BreweryMaster.API.Models.Work;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreweryMaster.API.Services
{
    public class TaskService : ITaskService
    {
        private readonly WorkDbContext _context;
        private readonly UserContext _userContext;

        public TaskService(WorkDbContext context, UserContext userContext)
        {
            _context = context;
            _userContext = userContext;
        }

        public async Task<Dictionary<string, Column>> GetKanbanTasksByOwnerIdAsync(int ownerId)
        {
            var tasks = await _context.KanbanTasks.Where(x => x.OwnerId == ownerId).ToListAsync();
            var owner = await _userContext.Employees.FirstOrDefaultAsync(x => x.ID == ownerId);

            var ownerName = string.Empty;

            if (owner != null)
                ownerName = UserHelper.GetFullName(owner.Forename, owner.Surname);

            var result = tasks.Select(x => KanbanTaskMapper.ToDto(x, ownerName));

            var columnsDictionary = Enum.GetValues(typeof(Models.Work.TaskStatus))
                .Cast<BreweryMaster.API.Models.Work.TaskStatus>()
                .ToDictionary(
                    status => Enum.GetName(typeof(Models.Work.TaskStatus), status),
                    status =>
                    {
                        var tasksForStatus = result.Where(t => (Models.Work.TaskStatus)t.Status == status).ToList();
                        return new Column
                        {
                            Title = $"Status {status}",
                            Status = (int)status,
                            Items = tasksForStatus
                        };
                    });

            return columnsDictionary;
        }

        public async Task<IEnumerable<KanbanTask>> GetKanbanTasksByOrderIdAsync(int orderId)
        {
            return await _context.KanbanTasks.Where(x => x.OrderId == orderId).ToListAsync();
        }

        public async Task<KanbanTask> GetKanbanTaskByIdAsync(int id)
        {
            return await _context.KanbanTasks.FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<KanbanTask> CreateKanbanTaskAsync(KanbanTask kanbanTask)
        {
            _context.KanbanTasks.Add(kanbanTask);
            await _context.SaveChangesAsync();
            return kanbanTask;
        }

        public async Task<bool> EditKanbanTaskAsync(int id, KanbanTask kanbanTask)
        {
            if (id != kanbanTask.ID)
                return false;

            _context.Entry(kanbanTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KanbanTaskExists(id))
                    return false;
                else
                    throw;
            }

            return true;
        }

        public async Task<bool> EditKanbanTaskStatusAsync(List<KanbanTaskStatusSaveRequest> request)
        {
            foreach (var item in request)
            {
                var task = await _context.KanbanTasks.FirstOrDefaultAsync(x => x.ID == item.ID);

                if (task != null)
                    task.Status = item.Status;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return true;
        }

        public async Task<bool> DeleteKanbanTaskByIdAsync(int id)
        {
            var kanbanTask = await _context.KanbanTasks.FirstOrDefaultAsync(x => x.ID == id);

            if (kanbanTask == null)
                return false;

            _context.KanbanTasks.Remove(kanbanTask);
            await _context.SaveChangesAsync();

            return true;
        }

        private bool KanbanTaskExists(int id)
        {
            return _context.KanbanTasks.Any(x => x.ID == id);
        }
    }
}
