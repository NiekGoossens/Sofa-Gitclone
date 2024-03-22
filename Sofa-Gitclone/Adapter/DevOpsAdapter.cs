namespace Sofa_Gitclone.Adapter;

public class DevOpsAdapter : IAzureDevOps {
    private DevOps _devOps;
    
    public DevOpsAdapter() {
        _devOps = new DevOps();
    }
    
    public void Sources() {
        _devOps.Sources();
    }

    public void Package() {
        _devOps.Package();
    }

    public void Build() {
        _devOps.Build();
    }

    public void Test() {
        _devOps.Test();
    }

    public void Analyze() {
        _devOps.Analyze();
    }

    public void Deploy() {
        _devOps.Deploy();
    }

    public void Utility() {
        _devOps.Utility();
    }
}