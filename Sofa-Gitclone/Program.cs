// See https://aka.ms/new-console-template for more information
using Sofa_Gitclone.Sprint;
using Sofa_Gitclone.Sprint.BacklogStates;
using System.Collections.Generic;


BacklogItem backlogItem = new BacklogItem("test", "test backlog item", 32, []);

// set backlogitem state to doing
backlogItem.SetState(new Doing());