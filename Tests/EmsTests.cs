using Tests;
using Xunit;
using Tests; // Replace with your actual namespace

public class TestCaseTests
{
    [Fact]
    public void TestEmsServiceParsing()
    {
        // Arrange
        var testCase = new TestCase();
        var emsTuples = testCase.test();

        // Act & Assert
        foreach (var tuple in emsTuples)
        {
            var controller = new EmsService(tuple.EMs);
            var parsed = controller.Parse();
            Assert.Contains(tuple.Representation, parsed);
        }
    }
}