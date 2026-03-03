using Benefits.Starter.Domain;
using Benefits.Starter.Domain.enums;
using Benefits.Starter.Service.Employees;
using Benefits.Starter.Test.Fakes;
using Xunit;

namespace Benefits.Starter.Test.Service.Employees;

public class EmployeeServiceTests
{
    private static CreateEmployeeRequest ValidRequest() =>
        new(
            Title.Ms,
            "Allegra",
            "Bourne",
            new DateOnly(1984, 1, 1),
            Gender.Female,
            "allegra@example.com",
            new Address("1 High Street", null, "York", "YO1 1AA", "UK"));

    [Fact]
    public async Task Given_EmailAlreadyExists_When_CreateEmployee_Then_ThrowsException_And_DoesNotPersist()
    {
        var repo = new FakeEmployeeRepository { EmailExists = true };
        var sut = new EmployeeService(repo);
        var request = ValidRequest();

        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            sut.CreateAsync(request, CancellationToken.None));

        Assert.Equal(0, repo.AddCallCount);
        Assert.Null(repo.AddedEmployee);
    }

    [Fact]
    public async Task Given_ValidRequest_When_CreateEmployee_Then_PersistsEmployee_And_ReturnsResult()
    {
        var repo = new FakeEmployeeRepository
        {
            EmailExists = false,
            EmployeeNoExists = false
        };

        var sut = new EmployeeService(repo);
        var request = ValidRequest();

        var result = await sut.CreateAsync(request, CancellationToken.None);

        Assert.NotEqual(Guid.Empty, result.Id);
        Assert.StartsWith("EMP", result.EmployeeNo);

        Assert.Equal(1, repo.AddCallCount);
        Assert.NotNull(repo.AddedEmployee);

        Assert.Equal(result.EmployeeNo, repo.AddedEmployee!.EmployeeNo);
        Assert.Equal(request.Email.Trim().ToLowerInvariant(), repo.AddedEmployee.Email);
    }
}