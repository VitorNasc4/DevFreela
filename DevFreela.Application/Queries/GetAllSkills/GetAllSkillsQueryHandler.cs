using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Queries.GetAllSkills;

public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, List<SkillViewModel>>
{
    private readonly DevFreelaDbContext _dbContext;

    public GetAllSkillsQueryHandler(DevFreelaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<SkillViewModel>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
    {
        var skillsViewModel = await _dbContext.Skills
            .Select(s => new SkillViewModel(s.Id, s.Description))
            .ToListAsync(cancellationToken);

        return skillsViewModel;
    }
}