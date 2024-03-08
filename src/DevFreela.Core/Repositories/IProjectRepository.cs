using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllAsync();
        Task<Project> GetDetailsByIdAsync(int id);
        Task<Project> GetByIdAsync(int id);
        Task AddCommentAsync(ProjectComment comment);
        Task AddAsync(Project project);
        Task SaveChangesAsync();
    }
}
