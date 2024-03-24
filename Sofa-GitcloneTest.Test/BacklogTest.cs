using Sofa_Gitclone.observer.NotificationTypes;
using Sofa_Gitclone.Sprint;
using Sofa_Gitclone.Sprint.BacklogStates;
using Sofa_Gitclone.Sprint.SprintFactories;
using Sofa_Gitclone.User;

namespace Sofa_Gitclone.Test;

public class BacklogTest {
    private Mock<BacklogItem> backlogItemMock = new Mock<BacklogItem>();
    
    private static User.User user1 = new("User1Test");
    private static User.User user2 = new("User2Dev");
    
    private static Project project = new("Project1");
    
    private static UserDecorator developer = new Developer(user2, project, new EmailNotification());
    private static UserDecorator tester = new Tester(user1, project, new EmailNotification());
    
    private static DateTime date = new DateTime(2021, 12, 12);
    private static DateTime date2 = new DateTime(2026, 12, 12);
    
    private static FeedbackSprintFactory feedbackSprintFactory = new FeedbackSprintFactory();
    private static Sprint.Sprint sprint =  feedbackSprintFactory.CreateSprint("new sprint", date, date2, project);
    
    private BacklogItem backlogItem = new("test", "test backlog item", 32, tester, sprint);

    [Fact]
    public void BacklogItemCanHaveActivities() {
        // Arrange
        Activity activity = new("test activity", tester);
        Activity secondActivity = new("second test activity", developer);
        
        // Act
        backlogItem.AddActivity(activity);
        backlogItem.AddActivity(secondActivity);
        
        // Assert
        Assert.Equal(2, backlogItem.activities.Count);
    }
    
    [Fact]
    public void BacklogItemCanFinishActivities() {
        // Arrange
        Activity activity = new("test activity", tester);
        Activity secondActivity = new("second test activity", developer);
        
        // Act
        backlogItem.AddActivity(activity);
        backlogItem.AddActivity(secondActivity);
        
        backlogItem.FinishActivity(0);
        backlogItem.FinishActivity(1);
        
        // Assert
        Assert.True(backlogItem.activities[0].IsDone);
        Assert.True(backlogItem.activities[1].IsDone);
    }
    
    [Fact]
    public void BacklogItemCanCreateDiscussions() {
        // Arrange
        string discussionName = "test discussion";
        string discussionDescription = "test discussion description";
        
        // Act
        backlogItem.State.CreateDiscussion(discussionName, discussionDescription, tester);
        
        // Assert
        Assert.Equal(1, backlogItem.discussions.Count);
    }
    
    [Fact]
    public void BacklogItemCanCloseDiscussions() {
        // Arrange
        string discussionName = "test discussion";
        string discussionDescription = "test discussion description";
        backlogItem.State.CreateDiscussion(discussionName, discussionDescription, tester);
        
        // Act
        sprint.backlogItems[1].discussions[0].Close();
        
        // Assert
        Assert.True(sprint.backlogItems[1].discussions[0].isClosed);
    }
    
    [Fact]
    public void BacklogItemCanCreateComments() {
        // Arrange
        string discussionName = "test discussion";
        string discussionDescription = "test discussion description";
        backlogItem.State.CreateDiscussion(discussionName, discussionDescription, tester);
        
        Comment comment = new("test comment", tester);
        
        // Act
        backlogItem.State.CreateComment(0, comment, tester);
        
        // Assert
        Assert.Equal(1, backlogItem.discussions[0].comments.Count);
    }
    
    [Fact]
    public void BacklogItemCanCreateCommentsOnComments() {
        // Arrange
        string discussionName = "test discussion";
        string discussionDescription = "test discussion description";
        backlogItem.State.CreateDiscussion(discussionName, discussionDescription, tester);
        
        Comment comment = new("test comment", tester);
        backlogItem.State.CreateComment(0, comment, tester);
        
        Comment comment2 = new("test comment 2", tester);
        
        // Act
        backlogItem.State.CreateComment(0, comment2, tester);
        
        // Assert
        Assert.Equal(2, backlogItem.discussions[0].comments.Count);
    }
    
    [Fact]
    public void BacklogItemCanChangeState() {
        // Act
        backlogItem.nextStep(developer);
        
        // Assert
        Assert.IsType<Doing>(backlogItem.State);
    }
    
    [Fact]
    public void BacklogItemCanChangeStateBack() {
        backlogItem.nextStep(developer);
        
        // Act
        backlogItem.previousStep(developer);
        
        // Assert
        Assert.IsType<ToDo>(backlogItem.State);
    }
    
    [Fact]
    public void BacklogItemCanChangeStateWithDifferentUser() {
        // Act
        backlogItem.nextStep(developer);
        backlogItem.nextStep(tester);
        
        // Assert
        Assert.IsType<ReadyForTesting>(backlogItem.State);
    }
    
    [Fact]
    public void BacklogItemCanChangeStateWithDifferentUserBack() {
        // Act
        backlogItem.nextStep(developer);
        backlogItem.previousStep(tester);
        
        // Assert
        Assert.IsType<ToDo>(backlogItem.State);
    }
}