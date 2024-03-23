// See https://aka.ms/new-console-template for more information
using Sofa_Gitclone;
using Sofa_Gitclone.observer;
using Sofa_Gitclone.Sprint;
using Sofa_Gitclone.Sprint.BacklogStates;
using Sofa_Gitclone.Sprint.Export;
using Sofa_Gitclone.Sprint.SprintFactories;
using Sofa_Gitclone.User;
using System.Collections.Generic;



// user

var user1 = new User("User1");
var user2 = new User("User2");


// project
var project = new Project("Project1");
var project2 = new Project("Project2");

//project.AddTester(user1);
//project.AddDeveloper(user2);
//project.AddProductOwner(user1);

// observer
Publisher publisher = new Publisher();
RoleDecorator productOwner = new ProductOwnerRoleDecorator(user1, project);
RoleDecorator developer = new DeveloperRoleDecorator(user2, project);
RoleDecorator tester = new TesterRoleDecorator(user1, project);

TesterRoleDecorator tester2 = new TesterRoleDecorator(user2, project2);

publisher.Subscribe(productOwner);
publisher.Subscribe(developer);
publisher.Notify();


DateTime date = new DateTime(2021, 12, 12);
DateTime date2 = new DateTime(2021, 12, 12);



// project add user
FeedbackSprintFactory feedbackSprintFactory = new FeedbackSprintFactory();
Sprint sprint =  feedbackSprintFactory.CreateSprint("new sprint", date, date2);
BacklogItem backlogItem = new BacklogItem("test", "test backlog item", 32, tester);
sprint.AddBacklogItem(backlogItem);

Console.WriteLine(sprint.backlogItems[0].Owner);
// 

sprint.backlogItems[0].nextStep(tester2);
tester2.Update();
publisher.Subscribe(tester2);
publisher.Notify();

sprint.AddUser(tester2);
sprint.AddUser(developer);

sprint.NotifyUsers();

SprintExport sprintExport = new PdfExport();
sprintExport.CreateExport(sprint);

BacklogItem backlogItem2 = new BacklogItem("test", "test backlog item", 32, tester);
sprint.AddBacklogItem(backlogItem2);

// create discussion
sprint.backlogItems[1].CreateDiscussion("discussion", "description", productOwner);

Console.WriteLine(sprint.backlogItems[1].discussions[0]);

//create comments
Comment comment = new Comment("comment", tester2);
sprint.backlogItems[0].CreateComment(0, comment);
// create comment on comment
Comment comment2 = new Comment("comment2", tester2);
sprint.backlogItems[0].CreateComment(0, comment2);

// close discussion
sprint.backlogItems[0].discussions[0].Close();