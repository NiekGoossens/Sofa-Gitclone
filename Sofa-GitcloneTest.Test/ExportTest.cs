using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Sofa_Gitclone.Sprint.Export;
using Sofa_Gitclone.Sprint.SprintFactories;

namespace Sofa_Gitclone.Test;

[Collection("Sequential")]

public class ExportTest {
    [Fact]
    public void ExportToPDF() {
        // Arrange
        var expected = "Exporting to PDF\r\nExporting Sprint: Feedback Sprint\r\n";
        using StringWriter sw = new();
        Console.SetOut(sw);

        SprintExport sprintExport = new PdfExport();
        Project project = new Project("Project");
        FeedbackSprintFactory feedbackFactory = new FeedbackSprintFactory();
        var sprint = feedbackFactory.CreateSprint("Feedback Sprint", DateTime.Now, DateTime.Now.AddDays(1), project);

        // Act
        sprintExport.CreateExport(sprint);

        // Assert
        Assert.Equal(expected, sw.ToString());
        
        // Reset the console output
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
    }

    [Fact]
    public void ExportToPNG() {
        // Arrange
        var expected = "Exporting to Png\r\nExporting Sprint: Feedback Sprint\r\n";
        using StringWriter sw = new();
        Console.SetOut(sw);

        SprintExport sprintExport = new PngExport();
        Project project = new Project("Project");
        FeedbackSprintFactory feedbackFactory = new FeedbackSprintFactory();
        var sprint = feedbackFactory.CreateSprint("Feedback Sprint", DateTime.Now, DateTime.Now.AddDays(1), project);

        // Act
        sprintExport.CreateExport(sprint);

        // Assert
        Assert.Equal(expected, sw.ToString());
        
        // Reset the console output
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
    }
} 