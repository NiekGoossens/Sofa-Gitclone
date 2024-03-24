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
        using StringWriter sw = new();
        Console.SetOut(sw);

        SprintExport sprintExport = new PdfExport();
        Project project = new Project("Project");
        FeedbackSprintFactory feedbackFactory = new FeedbackSprintFactory();
        var sprint = feedbackFactory.CreateSprint("Feedback Sprint", DateTime.Now, DateTime.Now.AddDays(1), project);

        // Act
        sprintExport.CreateExport(sprint, "Feedback Sprint", "Footer");

        // Assert
        var expected = "Exporting to PDF\nSprint export: " + "Feedback Sprint" + "\n" + sprint.project.Name + " " + sprint.name + " " + sprint.startDate + "\n" + "Footer\n";
        Assert.Equal(expected, sw.ToString());
        
        // Reset the console output
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
    }

    [Fact]
    public void ExportToPNG() {
        // Arrange
        using StringWriter sw = new();
        Console.SetOut(sw);

        SprintExport sprintExport = new PngExport();
        Project project = new Project("Project");
        FeedbackSprintFactory feedbackFactory = new FeedbackSprintFactory();
        var sprint = feedbackFactory.CreateSprint("Feedback Sprint", DateTime.Now, DateTime.Now.AddDays(1), project);

        // Act
        sprintExport.CreateExport(sprint, "Feedback Sprint", "Footer");

        // Assert
        var expected = "Exporting to Png\nSprint export: " + "Feedback Sprint" + "\n" + sprint.project.Name + " " + sprint.name + " " + sprint.startDate + "\n" + "Footer\n";
        Assert.Equal(expected, sw.ToString());
        
        // Reset the console output
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
    }
} 