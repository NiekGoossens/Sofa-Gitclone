namespace Sofa_Gitclone.Adapter;

public interface IGit {
    void Commit();
    void Push();
    void Pull();
    void Merge();
    void Branch();
}