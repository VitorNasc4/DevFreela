using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly DevFreelaDbContext _dbContext;

    public ProjectRepository(DevFreelaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Project>> GetAllAsync()
    {
        var projects = await _dbContext.Projects
            .ToListAsync();

        return projects;
    }

    public async Task<Project> GetDetailsByIdAsync(int id)
    {
        var project = await _dbContext.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .SingleOrDefaultAsync(p => p.Id == id);

        return project;
    }

    public async Task<Project> GetByIdAsync(int id)
    {
        var project = await _dbContext.Projects
                .SingleOrDefaultAsync(p => p.Id == id);

        return project;
    }

    public async Task AddCommentAsync(ProjectComment comment)
    {
        await _dbContext.ProjectComments.AddAsync(comment);
        await _dbContext.SaveChangesAsync();
    }

    public async Task AddAsync(Project project)
    {
        await _dbContext.Projects.AddAsync(project);
        await _dbContext.SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

}