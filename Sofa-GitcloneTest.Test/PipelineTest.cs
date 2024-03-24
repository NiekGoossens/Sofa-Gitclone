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
        var expected = "Running pipeline\r\nSources\r\nPackage\r\nBuild\r\nTest\r\nAnalyze\r\nDeploy\r\nUtility\r\n";
        Assert.Equal(expected, sw.ToString());
    }
}