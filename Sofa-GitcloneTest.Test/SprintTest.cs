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
        var expected = "Running pipeline\r\nSources\r\nPackage\r\nBuild\r\nTest\r\nAnalyze\r\nDeploy\r\nUtility\r\nSprint failed deployment\r\n";
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
        var expected = "Running pipeline\r\nSources\r\nPackage\r\nBuild\r\nTest\r\nAnalyze\r\nDeploy\r\nUtility\r\nSprint finished succesfully\r\n";
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
        var expected = "Sprint is finished, you can't perform this action\r\nRunning pipeline\r\nSources\r\nPackage\r\nBuild\r\nTest\r\nAnalyze\r\nDeploy\r\nUtility\r\nSprint failed deployment\r\n";
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

    [Fact]
    public void FeedbackSprint_StartReview_SetsIsReviewingToTrue() {
        // Arrange
        var sprint = new FeedbackSprint("Feedback Sprint", DateTime.Now, DateTime.Now.AddDays(1), new Project("Project 1"));

        // Act
        sprint.StartReview();

        // Assert
        Assert.True(sprint.IsReviewing);
    }

    [Fact]
    public void FeedbackSprint_UploadReview_SetsReview() {
        // Arrange
        var sprint = new FeedbackSprint("Feedback Sprint", DateTime.Now, DateTime.Now.AddDays(1), new Project("Project 1"));
        var review = "This is a review";

        // Act
        sprint.UploadReview(review);

        // Assert
        Assert.Equal(review, sprint.Review);
    }

    [Fact]
    public void FeedbackSprint_EndReview_SetsIsReviewingToFalseAndIsFinishedToTrue_WhenReviewIsNotNull() {
        // Arrange
        var sprint = new FeedbackSprint("Feedback Sprint", DateTime.Now, DateTime.Now.AddDays(1), new Project("Project 1"));
        sprint.UploadReview("This is a review");

        // Act
        sprint.EndReview();

        // Assert
        Assert.False(sprint.IsReviewing);
        Assert.True(sprint.IsFinished);
    }

    [Fact]
    public void FeedbackSprint_EndReview_KeepsIsReviewingTrueAndIsFinishedFalse_WhenReviewIsNull() {
        // Arrange
        var sprint = new FeedbackSprint("Feedback Sprint", DateTime.Now, DateTime.Now.AddDays(1), new Project("Project 1"));
        sprint.StartReview();

        // Act
        sprint.EndReview();

        // Assert
        Assert.True(sprint.IsReviewing);
        Assert.False(sprint.IsFinished);
    }
    
    [Fact]
    public void DeploymentSprint_CancelRelease_UpdatesProductOwner() {
        // Arrange
        using StringWriter sw = new();
        Console.SetOut(sw);
        Publisher publisher = new Publisher();
        var project = new Project("Project 1");
        var user = new User.User("UserTest");
        var productOwner = new ProductOwner(user, project, new EmailNotification());
        var sprint = new DeploymentSprint("Deployment Sprint", DateTime.Now, DateTime.Now.AddDays(1), project);
        project.AddProductOwner(productOwner);
        sprint.AddUser(productOwner);
        publisher.Subscribe(productOwner);

        // Act
        sprint.CancelRelease();

        // Assert
        var expected = "Canceled release for sprint: Deployment Sprint\r\n";
        Assert.Equal(expected, sw.ToString());
    }
}