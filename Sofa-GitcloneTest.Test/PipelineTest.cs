namespace Sofa_Gitclone.Test;

[Collection("Sequential")]
public class PipelineTest {
    [Fact]
    public void PipelineCanBeRun() {
        // Arrange
        using StringWriter sw = new();
        Console.SetOut(sw);
        Pipeline.Pipeline pipeline = new Pipeline.Pipeline();
        
        // Act
        pipeline.Run();
        
        // Assert
        var expected = "Running pipeline\nSources\nPackage\nBuild\nTest\nAnalyze\nDeploy\nUtility\n";
        Assert.Equal(expected, sw.ToString());
    }
}