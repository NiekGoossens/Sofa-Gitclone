namespace Sofa_Gitclone.Adapter;

public class GitAdapter : IGit {
    private GitSharp _gitSharp;
    
    public GitAdapter() {
        _gitSharp = new GitSharp();
    }
    
    public void Commit() {
        _gitSharp.Commit();
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