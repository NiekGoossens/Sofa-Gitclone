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

project.AddTester(user1);
project.AddDeveloper(user2);
project.AddProductOwner(user1);


//// project add user

//var adminDecorator = new ProductOwnerRoleDecorator(user1, project);
//var contributorDecorator = new DeveloperRoleDecorator(user2, project);
//var tester = new TesterRoleDecorator(user2, project);

//var adminDecorator2 = new ProductOwnerRoleDecorator(user2, project2);

//BacklogItem backlogItem = new BacklogItem("test", "test backlog item", 32, []);

//// set backlogitem state to doing
//Console.WriteLine(backlogItem.State);
//backlogItem.nextStep(adminDecorator);
//backlogItem.nextStep(adminDecorator);
//backlogItem.nextStep(adminDecorator);
//backlogItem.nextStep(adminDecorator);
//backlogItem.nextStep(adminDecorator);
//backlogItem.nextStep(adminDecorator);
//Console.WriteLine(backlogItem.State);
//backlogItem.nextStep(adminDecorator);
//Console.WriteLine(backlogItem.State);
//backlogItem.nextStep(tester);
//Console.WriteLine(backlogItem.State);

//Console.WriteLine(adminDecorator);

//Console.WriteLine(contributorDecorator);

//Console.WriteLine(adminDecorator2);

//// observer
//Publisher publisher = new Publisher();
//ISubscriber subscriber = new ProductOwnerRoleDecorator(user1, project);
//ISubscriber subscriber2 = new DeveloperRoleDecorator(user2, project);

//publisher.Subscribe(subscriber);
//publisher.Subscribe(subscriber2);
//publisher.Notify();

// notificaties via bepaald platform
// geef user platform mee en gebruik methode van dit platform
// notificaties naar bepaalde personen
// geef notificatie groep mee in notify methode en gebruik override in roles voor controle of deze gebruiker in groep zit
// hoe doen we dat max 1 iemand product owner is
// 