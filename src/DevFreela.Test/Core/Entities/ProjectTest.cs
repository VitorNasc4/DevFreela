using DevFreela.Core.Entities;
using DevFreela.Core.Enums;
using Xunit;

namespace DevFreela.Test.Core.Entities;

public class ProjectTest
{
  [Fact]
  public void TestIfProjectStartWorks()
  {
    var project = new Project("Titulo", "descrição", 1, 2, 100);

    Assert.Equal(ProjectStatusEnum.Created, project.Status);
    Assert.Null(project.StartedAt);

    project.Start();

    Assert.Equal(ProjectStatusEnum.InProgress, project.Status);
    Assert.NotNull(project.StartedAt);
  }

  [Fact]
  public void TestIfProjectFinishWorks()
  {
    var project = new Project("Titulo", "descrição", 1, 2, 100);
    Assert.Null(project.FinishedAt);

    project.Start();
    project.Finish();

    Assert.Equal(ProjectStatusEnum.Finished, project.Status);
    Assert.NotNull(project.FinishedAt);
  }

  [Fact]
  public void TestIfProjectCancelWorks()
  {
    var project = new Project("Titulo", "descrição", 1, 2, 100);

    project.Cancel();

    Assert.Equal(ProjectStatusEnum.Cancelled, project.Status);
  }

  [Fact]
  public void TestIfProjectUpdateWorks()
  {
    var project = new Project("Titulo", "descrição", 1, 2, 100);
    var newTitle = "Novo Titulo";
    var newDescription = "nova descrição";
    var newCost = 150;

    project.Update(newTitle, newDescription, newCost);

    Assert.Equal(newTitle, project.Title);
    Assert.Equal(newDescription, project.Description);
    Assert.Equal(newCost, project.TotalCost);
  }
}