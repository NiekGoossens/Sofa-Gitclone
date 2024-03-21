// See https://aka.ms/new-console-template for more information
using Sofa_Gitclone;
using Sofa_Gitclone.observer;
using Sofa_Gitclone.Sprint;
using Sofa_Gitclone.Sprint.BacklogStates;
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
ISubscriber productOwner = new ProductOwnerRoleDecorator(user1, project);
ISubscriber developer = new DeveloperRoleDecorator(user2, project);
ISubscriber tester = new TesterRoleDecorator(user1, project);

publisher.Subscribe(productOwner);
publisher.Subscribe(developer);
publisher.Notify();





// project add user

Sprint sprint = new Sprint("Sprint1", project, );
BacklogItem backlogItem = new BacklogItem("test", "test backlog item", 32, tester);



// set backlogitem state to doing
//Console.WriteLine(backlogItem.State);
//backlogItem.nextStep(developer);
//backlogItem.nextStep(developer);
//backlogItem.nextStep(developer);
//backlogItem.nextStep(developer);
//backlogItem.nextStep(developer);
//backlogItem.nextStep(developer);
//Console.WriteLine(backlogItem.State);
//backlogItem.nextStep(adminDecorator);
//Console.WriteLine(backlogItem.State);
//backlogItem.nextStep(tester);
//Console.WriteLine(backlogItem.State);

//Console.WriteLine(adminDecorator);

//Console.WriteLine(contributorDecorator);

//Console.WriteLine(adminDecorator2);
