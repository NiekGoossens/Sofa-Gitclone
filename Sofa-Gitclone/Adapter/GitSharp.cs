﻿using Sofa_Gitclone.Sprint;

namespace Sofa_Gitclone.Adapter;

public class GitSharp {
    public void Commit(BacklogItem backlogItem) {
        Console.WriteLine("Committing changes using GitSharp to the backlog item: " + backlogItem.Title);
    }
    
    public void Push() {
        Console.WriteLine("Pushing changes using GitSharp");
    }
    
    public void Pull() {
        Console.WriteLine("Pulling changes using GitSharp");
    }
    
    public void Merge() {
        Console.WriteLine("Merging changes using GitSharp");
    }
    
    public void Branch() {
        Console.WriteLine("Creating a new branch using GitSharp");
    }
}