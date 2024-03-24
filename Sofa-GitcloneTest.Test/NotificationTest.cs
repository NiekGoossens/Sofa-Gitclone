﻿using System.Text;
using Sofa_Gitclone.observer;
using Sofa_Gitclone.observer.NotificationTypes;
using Sofa_Gitclone.Sprint;
using Sofa_Gitclone.Sprint.SprintFactories;
using Sofa_Gitclone.User;

namespace Sofa_Gitclone.Test;
[Collection("Sequential")]
public class NotificationTest {
    // private Mock<ISubscriber> _subscriberMock;
    //
    // public NotificationTest() {
    //     _subscriberMock = new Mock<ISubscriber>();
    // }
    
    [Fact]
    public void UserShouldGetCorrectMessageOnEmailNotificationWhenNotified() {
        // Arrange
        var expected = "Email notification: testmessage\r\n";
        using StringWriter sw = new();
        Console.SetOut(sw);
        
        Publisher publisher = new Publisher();
        User.User user = new User.User("UserTest");
        Project project = new Project("ProjectTest");
        UserDecorator developer = new Developer(user, project, new EmailNotification());
        
        // Act
        publisher.Subscribe(developer);
        publisher.Notify("testmessage");
        
        // Assert
        Assert.Equal(expected, sw.ToString());
        
        // Reset the console output
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
    }
    
    [Fact]
    public void UserShouldGetCorrectMessageOnSlackNotificationWhenNotified() {
        // Arrange
        var expected = "Slack notification: testmessage\r\n";
        using StringWriter sw = new();
        Console.SetOut(sw);
        
        Publisher publisher = new Publisher();
        User.User user = new User.User("UserTest");
        Project project = new Project("ProjectTest");
        UserDecorator developer = new Developer(user, project, new SlackNotification());
        
        // Act
        publisher.Subscribe(developer);
        publisher.Notify("testmessage");
        
        // Assert
        Assert.Equal(expected, sw.ToString());
        
        // Reset the console output
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
    }
    
    [Fact]
    public void UserShouldGetCorrectMessageOnSlackNotificationWhenUnsubscribed() {
        // Arrange
        var expected = "";
        using StringWriter sw = new();
        Console.SetOut(sw);
        
        Publisher publisher = new Publisher();
        User.User user = new User.User("UserTest");
        Project project = new Project("ProjectTest");
        UserDecorator developer = new Developer(user, project, new SlackNotification());
        
        // Act
        publisher.Subscribe(developer);
        publisher.UnSubscribe(developer);
        publisher.Notify("testmessage");
        
        // Assert
        Assert.Equal(expected, sw.ToString());
        
        // Reset the console output
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
    }
    
    [Fact]
    public void UserShouldGetCorrectMessageOnEmailNotificationWhenUnsubscribed() {
        // Arrange
        var expected = "";
        using StringWriter sw = new();
        Console.SetOut(sw);
        
        Publisher publisher = new Publisher();
        User.User user = new User.User("UserTest");
        Project project = new Project("ProjectTest");
        UserDecorator developer = new Developer(user, project, new EmailNotification());
        
        // Act
        publisher.Subscribe(developer);
        publisher.UnSubscribe(developer);
        publisher.Notify("testmessage");
        
        // Assert
        Assert.Equal(expected, sw.ToString());
        
        // Reset the console output
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
    }

    [Fact]
    public void AllUsersInSprintShouldBeNotified() {
        // Arrange
        var expected = "Email notification: testing all sprint members\r\n";
        using StringWriter sw = new();
        Console.SetOut(sw);
        
        Publisher publisher = new Publisher();
        User.User user = new User.User("UserTest");
        Project project = new Project("ProjectTest");
        UserDecorator developer = new Developer(user, project, new EmailNotification());
        UserDecorator tester = new Tester(user, project, new EmailNotification());
        UserDecorator productOwner = new ProductOwner(user, project, new EmailNotification());
        FeedbackSprintFactory feedbackSprintFactory = new FeedbackSprintFactory();
        var sprint = feedbackSprintFactory.CreateSprint("TestSpring", DateTime.Now, DateTime.Now.AddDays(1), project);
        
        // Act
        publisher.Subscribe(developer);
        publisher.Subscribe(tester);
        publisher.Subscribe(productOwner);
        
        sprint.AddUser(developer);
        sprint.AddUser(tester);
        sprint.AddUser(productOwner);
        
        sprint.NotifyUsers("testing all sprint members");
        
        // Assert
        Assert.Equal(expected+expected+"testing all sprint members\r\n", sw.ToString());
        
        // Reset the console output
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
    }
}