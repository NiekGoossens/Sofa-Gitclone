using Sofa_Gitclone.observer.NotificationTypes;
using Sofa_Gitclone.Sprint;
using Sofa_Gitclone.Sprint.SprintFactories;
using Sofa_Gitclone.User;

namespace Sofa_Gitclone.Test;

public class ProjectTest {
    [Fact]
    public void ProjectShouldHaveName() {
        // Arrange
        Project project = new Project("Sofa-Gitclone");
        
        // Act & Assert
        Assert.Equal("Sofa-Gitclone", project.Name);
    }

    [Fact]
    public void ProjectCanAddUser() {
        // Arrange
        Project project = new Project("Sofa-Gitclone");
        User.User user = new User.User("UserTest");
        UserDecorator productOwner = new ProductOwner(user, project, new EmailNotification());
        
        // Act
        project.AddUser(productOwner);
        
        // Assert
        Assert.Equal(1, project.Users.Count);
    }
    
    [Fact]
    public void ProjectCanAddProductOwner() {
        // Arrange
        Project project = new Project("Sofa-Gitclone");
        User.User user = new User.User("UserTest");
        UserDecorator productOwner = new ProductOwner(user, project, new EmailNotification());
        
        // Act
        project.AddProductOwner(productOwner);
        
        // Assert
        Assert.Equal(productOwner, project.ProductOwner);
    }
    
    [Fact]
    public void ProjectCanCommitBacklogItem() {
        // Arrange
        using StringWriter sw = new();
        Console.SetOut(sw);
        Project project = new Project("Sofa-Gitclone");
        User.User user = new User.User("UserTest");
        UserDecorator productOwner = new ProductOwner(user, project, new EmailNotification());
        FeedbackSprintFactory factory = new FeedbackSprintFactory();
        var sprint = factory.CreateSprint("Feedback Sprint", DateTime.Now, DateTime.Now.AddDays(1), project);
        project.AddProductOwner(productOwner);
        
        BacklogItem backlogItem = new("test", "test backlog item", 32, productOwner, sprint);
        
        // Act
        project.Commit(backlogItem);
        
        // Assert
        var expected = "Committing changes using GitSharp to the backlog item: " + backlogItem.Title + "\r\n";
        Assert.Equal(expected, sw.ToString());
    }
}