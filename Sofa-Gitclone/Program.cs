// See https://aka.ms/new-console-template for more information
using Sofa_Gitclone;
using Sofa_Gitclone.Sprint;
using Sofa_Gitclone.Sprint.BacklogStates;
using Sofa_Gitclone.User;
using System.Collections.Generic;


BacklogItem backlogItem = new BacklogItem("test", "test backlog item", 32, []);

// set backlogitem state to doing
Console.WriteLine(backlogItem.State);
backlogItem.nextStep();
Console.WriteLine(backlogItem.State);


// user

var user1 = new User( "User1" );
var user2 = new User( "User2" );

// project
var project = new Project("Project1");
var project2 = new Project("Project2");

// project add user

var adminDecorator = new ProductOwnerRoleDecorator(user1, project);
var contributorDecorator = new DeveloperRoleDecorator(user2, project);

var adminDecorator2 = new ProductOwnerRoleDecorator(user2, project2);

Console.WriteLine(adminDecorator);

Console.WriteLine(contributorDecorator);

Console.WriteLine(adminDecorator2);

Console.WriteLine(adminDecorator.canMarkAsDone());
Console.WriteLine(adminDecorator.canDeploy());
Console.WriteLine(contributorDecorator.canMarkAsDone());