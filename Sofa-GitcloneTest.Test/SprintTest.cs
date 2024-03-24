using Sofa_Gitclone.observer;
using Sofa_Gitclone.observer.NotificationTypes;
using Sofa_Gitclone.Sprint.SprintFactories;
using Sofa_Gitclone.User;

namespace Sofa_Gitclone.Test;

[Collection("Sequential")]
public class SprintTest {
    [Fact]
    public void FeedbackSprintCanBeCreated() {
        // Arrange
        Project project = new Project("Project 1");
        FeedbackSprintFactory factory = new FeedbackSprintFactory();
        
        // Act
        var sprint = factory.CreateSprint("Feedback Sprint", DateTime.Now, DateTime.Now.AddDays(1), project);
        
        // Assert
        Assert.Equal("Feedback Sprint", sprint.name);
    }

    [Fact]
    public void DeploymentSprintCanBeCreated() {
        // Arrange
        Project project = new Project("Project 1");
        DeploymentSprintFactory factory = new DeploymentSprintFactory();
        
        // Act
        var sprint = factory.CreateSprint("Deployment Sprint", DateTime.Now, DateTime.Now.AddDays(1), project);
        
        // Assert
        Assert.Equal("Deployment Sprint", sprint.name);
    }

    [Fact]
    public void CanPerFormSprintFailsIfEndDateHasPassed() {
        // Arrange
        Project project = new Project("Project 1");
        DeploymentSprintFactory factory = new DeploymentSprintFactory();
        var sprint = factory.CreateSprint("Deployment Sprint", new DateTime(2024, 1, 10), new DateTime(2024, 1, 11), project);
        
        // Act
        sprint.CanPerform();
        
        // Assert
        Assert.False(sprint.CanPerform());
    }
    
    [Fact]
    public void CanPerFormSprintSucceedsIfEndDateHasNotPassed() {
        // Arrange
        Project project = new Project("Project 1");
        DeploymentSprintFactory factory = new DeploymentSprintFactory();
        var sprint = factory.CreateSprint("Deployment Sprint", DateTime.Now, DateTime.Now.AddDays(1), project);
        
        // Act
        sprint.CanPerform();
        
        // Assert
        Assert.True(sprint.CanPerform());
    }
    
    [Fact]
    public void UpdateSprint_ChangesValuesBeforeStart() {
        // Arrange
        Project project = new Project("Project 1");
        DeploymentSprintFactory factory = new DeploymentSprintFactory();
        var sprint = factory.CreateSprint("Deployment Sprint", DateTime.Now, DateTime.Now.AddDays(1), project);

        // Act
        sprint.UpdateSprint("Updated Sprint", DateTime.Now.AddDays(2), DateTime.Now.AddDays(3));

        // Assert
        Assert.Equal("Updated Sprint", sprint.name);
        Assert.Equal(DateTime.Now.AddDays(2).ToString("d"), sprint.startDate.ToString("d"));
        Assert.Equal(DateTime.Now.AddDays(3).ToString("d"), sprint.endDate.ToString("d"));
    }

    [Fact]
    public void UpdateSprint_DoesNotChangeValuesAfterStart() {
        // Arrange
        Project project = new Project("Project 1");
        DeploymentSprintFactory factory = new DeploymentSprintFactory();
        var sprint = factory.CreateSprint("Deployment Sprint", DateTime.Now, DateTime.Now.AddDays(1), project);
        sprint.StartSprint();

        // Act
        sprint.UpdateSprint("Updated Sprint", DateTime.Now.AddDays(2), DateTime.Now.AddDays(3));

        // Assert
        Assert.Equal("Deployment Sprint", sprint.name);
        Assert.Equal(DateTime.Now.ToString("d"), sprint.startDate.ToString("d"));
        Assert.Equal(DateTime.Now.AddDays(1).ToString("d"), sprint.endDate.ToString("d"));
    }

    [Fact]
    public void Finish_UpdatesProductOwnerOnFailure() {
        // Arrange
        using StringWriter sw = new();
        Console.SetOut(sw);
        Project project = new Project("Project 1");
        Publisher publisher = new Publisher();
        DeploymentSprintFactory factory = new DeploymentSprintFactory();
        User.User user = new User.User("UserTest");
        UserDecorator productOwner = new ProductOwner(user, project, new EmailNotification());
        var sprint = factory.CreateSprint("Deployment Sprint", DateTime.Now, DateTime.Now.AddDays(1), project);
        project.AddProductOwner(productOwner);
        publisher.Subscribe(productOwner);
        sprint.AddUser(productOwner);
        sprint.StartSprint();

        // Act
        sprint.Finish(false);

        // Assert
        var expected = "Running pipeline\r\nBuild\r\nTest\r\nDeploy\r\nSprint failed deployment\r\n";
        Assert.Equal(expected, sw.ToString());
        
        // Reset the console output
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
    }

    [Fact]
    public void Finish_UpdatesProductOwnerOnSuccess() {
        // Arrange
        using StringWriter sw = new();
        Console.SetOut(sw);
        Project project = new Project("Project 1");
        Publisher publisher = new Publisher();
        DeploymentSprintFactory factory = new DeploymentSprintFactory();
        User.User user = new User.User("UserTest");
        UserDecorator productOwner = new ProductOwner(user, project, new EmailNotification());
        var sprint = factory.CreateSprint("Deployment Sprint", DateTime.Now, DateTime.Now.AddDays(1), project);
        project.AddProductOwner(productOwner);
        publisher.Subscribe(productOwner);
        sprint.AddUser(productOwner);
        sprint.StartSprint();

        // Act
        sprint.Finish(true);

        // Assert
        var expected = "Running pipeline\r\nBuild\r\nTest\r\nDeploy\r\nSprint finished succesfully\r\n";
        Assert.Equal(expected, sw.ToString());
        
        // Reset the console output
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
    }

    [Fact]
    public void CheckSprint_FinishesSprintAfterEndDate() {
        // Arrange
        using StringWriter sw = new();
        Console.SetOut(sw);
        Project project = new Project("Project 1");
        Publisher publisher = new Publisher();
        DeploymentSprintFactory factory = new DeploymentSprintFactory();
        User.User user = new User.User("UserTest");
        UserDecorator productOwner = new ProductOwner(user, project, new EmailNotification());
        var sprint = factory.CreateSprint("Deployment Sprint", DateTime.Now.AddDays(-2), DateTime.Now.AddDays(-1), project);
        project.AddProductOwner(productOwner);
        publisher.Subscribe(productOwner);
        sprint.AddUser(productOwner);
        sprint.StartSprint();

        // Act
        sprint.CheckSprint();

        // Assert
        var expected = "Sprint is finished, you can't perform this action\r\nRunning pipeline\r\nBuild\r\nTest\r\nDeploy\r\nSprint failed deployment\r\n";
        Assert.Equal(expected, sw.ToString());
        
        // Reset the console output
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
    }

    [Fact]
    public void CanRemoveUserFromSprint() {
        // Arrange
        using StringWriter sw = new();
        Console.SetOut(sw);
        Project project = new Project("Project 1");
        Publisher publisher = new Publisher();
        DeploymentSprintFactory factory = new DeploymentSprintFactory();
        User.User user = new User.User("UserTest");
        UserDecorator productOwner = new ProductOwner(user, project, new EmailNotification());
        var sprint = factory.CreateSprint("Deployment Sprint", DateTime.Now.AddDays(-2), DateTime.Now.AddDays(-1), project);
        project.AddProductOwner(productOwner);
        publisher.Subscribe(productOwner);
        sprint.AddUser(productOwner);
        sprint.StartSprint();
        
        // Act
        sprint.RemoveUser(productOwner);
        
        // Assert
        Assert.Empty(sprint.users);
    }
}