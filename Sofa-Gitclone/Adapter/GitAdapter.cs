using Sofa_Gitclone.Sprint;

namespace Sofa_Gitclone.Adapter;

public class GitAdapter : IGit {
    private GitSharp _gitSharp;
    
    public GitAdapter() {
        _gitSharp = new GitSharp();
    }
    
    public void Commit(BacklogItem backlogItem) {
        _gitSharp.Commit(backlogItem);
    }
    
    public void Push() {
        _gitSharp.Push();
    }
    
    public void Pull() {
        _gitSharp.Pull();
    }
    
    public void Merge() {
        _gitSharp.Merge();
    }
    
    public void Branch() {
        _gitSharp.Branch();
    }
}