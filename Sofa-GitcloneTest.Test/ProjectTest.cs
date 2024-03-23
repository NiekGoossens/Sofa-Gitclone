namespace Sofa_Gitclone.Test;

public class ProjectTest {
    [Fact]
    public void ProjectShouldHaveName() {
        Project project = new Project("Sofa-Gitclone");
        Assert.Equal("Sofa-Gitclone", project.Name);
    }
}