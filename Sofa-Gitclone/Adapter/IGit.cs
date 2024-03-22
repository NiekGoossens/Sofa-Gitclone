using Sofa_Gitclone.Sprint;

namespace Sofa_Gitclone.Adapter;

public interface IGit {
    void Commit(BacklogItem backlogItem);
    void Push();
    void Pull();
    void Merge();
    void Branch();
}