namespace Sofa_Gitclone.Adapter;

public interface IAzureDevOps {
    void Sources();
    void Package();
    void Build();
    void Test();
    void Analyze();
    void Deploy();
    void Utility();
}