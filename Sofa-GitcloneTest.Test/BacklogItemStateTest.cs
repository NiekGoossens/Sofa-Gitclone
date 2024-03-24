using Sofa_Gitclone.observer.NotificationTypes;
using Sofa_Gitclone.Sprint;
using Sofa_Gitclone.Sprint.BacklogStates;
using Sofa_Gitclone.Sprint.SprintFactories;
using Sofa_Gitclone.User;

namespace Sofa_Gitclone.Test;

public class BacklogItemStateTest {
    [Fact]
    public void ToDoStateShouldChangeStateToDoing() {
        // Arrange
        Project project = new Project("Project");
        User.User user = new User.User("User");
        UserDecorator productOwner = new ProductOwner(user, project, new EmailNotification());
        FeedbackSprintFactory feedbackFactory = new FeedbackSprintFactory();
        var sprint = feedbackFactory.CreateSprint("Feedback Sprint", DateTime.Now, DateTime.Now.AddDays(1), project);
        BacklogItem backlogItem = new("test", "test backlog item", 32, productOwner, sprint);
        
        // Act
        backlogItem.nextStep(productOwner);
        
        // Assert
        Assert.IsType<Doing>(backlogItem.State);
    }
    
    [Fact]
    public void DoingStateShouldChangeStateToToDo() {
        // Arrange
        Project project = new Project("Project");
        User.User user = new User.User("User");
        UserDecorator productOwner = new ProductOwner(user, project, new EmailNotification());
        FeedbackSprintFactory feedbackFactory = new FeedbackSprintFactory();
        var sprint = feedbackFactory.CreateSprint("Feedback Sprint", DateTime.Now, DateTime.Now.AddDays(1), project);
        BacklogItem backlogItem = new("test", "test backlog item", 32, productOwner, sprint);
        backlogItem.nextStep(productOwner);
        
        // Act
        backlogItem.previousStep(productOwner);
        
        // Assert
        Assert.IsType<ToDo>(backlogItem.State);
    }
    
    [Fact]
    public void DoingStateShouldNotChangeStateToReadyForTestingWhenThereAreUnfinishedActivities() {
        // Arrange
        Project project = new Project("Project");
        User.User user = new User.User("User");
        UserDecorator productOwner = new ProductOwner(user, project, new EmailNotification());
        FeedbackSprintFactory feedbackFactory = new FeedbackSprintFactory();
        var sprint = feedbackFactory.CreateSprint("Feedback Sprint", DateTime.Now, DateTime.Now.AddDays(1), project);
        BacklogItem backlogItem = new("test", "test backlog item", 32, productOwner, sprint);
        Activity activity = new("test activity", productOwner);
        Activity secondActivity = new("second test activity", productOwner);
        backlogItem.AddActivity(activity);
        backlogItem.AddActivity(secondActivity);
        backlogItem.FinishActivity(0);
        backlogItem.nextStep(productOwner);
        
        // Act
        backlogItem.nextStep(productOwner);
        
        // Assert
        Assert.IsType<Doing>(backlogItem.State);
    }
    
    [Fact]
    public void DoingStateShouldChangeStateToReadyForTestingWhenAllActivitiesAreFinished() {
        // Arrange
        Project project = new Project("Project");
        User.User user = new User.User("User");
        UserDecorator productOwner = new ProductOwner(user, project, new EmailNotification());
        FeedbackSprintFactory feedbackFactory = new FeedbackSprintFactory();
        var sprint = feedbackFactory.CreateSprint("Feedback Sprint", DateTime.Now, DateTime.Now.AddDays(1), project);
        BacklogItem backlogItem = new("test", "test backlog item", 32, productOwner, sprint);
        Activity activity = new("test activity", productOwner);
        Activity secondActivity = new("second test activity", productOwner);
        backlogItem.AddActivity(activity);
        backlogItem.AddActivity(secondActivity);
        backlogItem.FinishActivity(0);
        backlogItem.FinishActivity(1);
        backlogItem.nextStep(productOwner);
        
        // Act
        backlogItem.nextStep(productOwner);
        
        // Assert
        Assert.IsType<ReadyForTesting>(backlogItem.State);
    }

    [Fact]
    public void ReadyForTestingStateShouldChangeStateToToDo() {
        // Arrange
        Project project = new Project("Project");
        User.User user = new User.User("User");
        UserDecorator productOwner = new ProductOwner(user, project, new EmailNotification());
        UserDecorator tester = new Tester(user, project, new EmailNotification());
        FeedbackSprintFactory feedbackFactory = new FeedbackSprintFactory();
        var sprint = feedbackFactory.CreateSprint("Feedback Sprint", DateTime.Now, DateTime.Now.AddDays(1), project);
        BacklogItem backlogItem = new("test", "test backlog item", 32, productOwner, sprint);
        project.AddProductOwner(productOwner);
        backlogItem.nextStep(tester);
        backlogItem.nextStep(tester);
        
        // Act
        backlogItem.previousStep(tester);
        
        // Assert
        Assert.IsType<ToDo>(backlogItem.State);
    }
    
    [Fact]
    public void ReadyForTestingStateShouldChangeStateToTested() {
        // Arrange
        Project project = new Project("Project");
        User.User user = new User.User("User");
        UserDecorator productOwner = new ProductOwner(user, project, new EmailNotification());
        UserDecorator tester = new Tester(user, project, new EmailNotification());
        FeedbackSprintFactory feedbackFactory = new FeedbackSprintFactory();
        var sprint = feedbackFactory.CreateSprint("Feedback Sprint", DateTime.Now, DateTime.Now.AddDays(1), project);
        BacklogItem backlogItem = new("test", "test backlog item", 32, productOwner, sprint);
        project.AddProductOwner(productOwner);
        backlogItem.nextStep(tester);
        backlogItem.nextStep(tester);
        
        // Act
        backlogItem.nextStep(tester);
        
        // Assert
        Assert.IsType<Tested>(backlogItem.State);
    }
    
    [Fact]
    public void TestedStateShouldChangeStateToReadyForTesting() {
        // Arrange
        Project project = new Project("Project");
        User.User user = new User.User("User");
        UserDecorator productOwner = new ProductOwner(user, project, new EmailNotification());
        UserDecorator tester = new Tester(user, project, new EmailNotification());
        FeedbackSprintFactory feedbackFactory = new FeedbackSprintFactory();
        var sprint = feedbackFactory.CreateSprint("Feedback Sprint", DateTime.Now, DateTime.Now.AddDays(1), project);
        BacklogItem backlogItem = new("test", "test backlog item", 32, productOwner, sprint);
        project.AddProductOwner(productOwner);
        backlogItem.nextStep(tester);
        backlogItem.nextStep(tester);
        backlogItem.nextStep(tester);
        
        // Act
        backlogItem.previousStep(tester);
        
        // Assert
        Assert.IsType<ReadyForTesting>(backlogItem.State);
    }
    
    [Fact]
    public void TestedStateShouldChangeStateToDone() {
        // Arrange
        Project project = new Project("Project");
        User.User user = new User.User("User");
        UserDecorator productOwner = new ProductOwner(user, project, new EmailNotification());
        UserDecorator tester = new Tester(user, project, new EmailNotification());
        FeedbackSprintFactory feedbackFactory = new FeedbackSprintFactory();
        var sprint = feedbackFactory.CreateSprint("Feedback Sprint", DateTime.Now, DateTime.Now.AddDays(1), project);
        BacklogItem backlogItem = new("test", "test backlog item", 32, productOwner, sprint);
        project.AddProductOwner(productOwner);
        backlogItem.nextStep(tester);
        backlogItem.nextStep(tester);
        backlogItem.nextStep(tester);
        
        // Act
        backlogItem.nextStep(tester);
        
        // Assert
        Assert.IsType<Done>(backlogItem.State);
    }
    
    [Fact]
    public void DoneStateShouldChangeStateToTested() {
        // Arrange
        Project project = new Project("Project");
        User.User user = new User.User("User");
        UserDecorator productOwner = new ProductOwner(user, project, new EmailNotification());
        UserDecorator tester = new Tester(user, project, new EmailNotification());
        FeedbackSprintFactory feedbackFactory = new FeedbackSprintFactory();
        var sprint = feedbackFactory.CreateSprint("Feedback Sprint", DateTime.Now, DateTime.Now.AddDays(1), project);
        BacklogItem backlogItem = new("test", "test backlog item", 32, productOwner, sprint);
        project.AddProductOwner(productOwner);
        backlogItem.nextStep(tester);
        backlogItem.nextStep(tester);
        backlogItem.nextStep(tester);
        backlogItem.nextStep(tester);
        
        // Act
        backlogItem.previousStep(tester);
        
        // Assert
        Assert.IsType<Tested>(backlogItem.State);
    }

    [Fact]
    public void CannotCreateDiscussionInDoneState() {
        // Arrange
        using StringWriter sw = new();
        Console.SetOut(sw);
        
        Project project = new Project("Project");
        User.User user = new User.User("User");
        UserDecorator productOwner = new ProductOwner(user, project, new EmailNotification());
        UserDecorator tester = new Tester(user, project, new EmailNotification());
        FeedbackSprintFactory feedbackFactory = new FeedbackSprintFactory();
        var sprint = feedbackFactory.CreateSprint("Feedback Sprint", DateTime.Now, DateTime.Now.AddDays(1), project);
        BacklogItem backlogItem = new("test", "test backlog item", 32, productOwner, sprint);
        project.AddProductOwner(productOwner);
        backlogItem.nextStep(tester);
        backlogItem.nextStep(tester);
        backlogItem.nextStep(tester);
        backlogItem.nextStep(tester);
        
        // Act
        backlogItem.State.CreateDiscussion("test discussion", "test discussion description", tester);
        
        // Assert
        var expected = "Cannot create discussions for finished items";
        Assert.Empty(backlogItem.discussions);
        
        // Reset the console output
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
    }
    
    [Fact]
    public void CannotCreateCommentInDoneState() {
        // Arrange
        using StringWriter sw = new();
        Console.SetOut(sw);
        
        Project project = new Project("Project");
        User.User user = new User.User("User");
        UserDecorator productOwner = new ProductOwner(user, project, new EmailNotification());
        UserDecorator tester = new Tester(user, project, new EmailNotification());
        FeedbackSprintFactory feedbackFactory = new FeedbackSprintFactory();
        var sprint = feedbackFactory.CreateSprint("Feedback Sprint", DateTime.Now, DateTime.Now.AddDays(1), project);
        BacklogItem backlogItem = new("test", "test backlog item", 32, productOwner, sprint);
        project.AddProductOwner(productOwner);
        backlogItem.nextStep(tester);
        backlogItem.nextStep(tester);
        backlogItem.nextStep(tester);
        backlogItem.nextStep(tester);
        
        // Act
        backlogItem.State.CreateComment(1, new Comment("test comment", tester), tester);
        
        // Assert
        var expected = "Cannot create comments for finished items";
        Assert.Empty(backlogItem.discussions);
        
        // Reset the console output
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
    }
}