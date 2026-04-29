using Application.Dtos.Results;
using Presentation.WebApp.Models;
using System.ComponentModel.DataAnnotations;

namespace Tests;

public class AuthTests
{
    private static IList<ValidationResult> Validate(object model)
    {
        var results = new List<ValidationResult>();
        var context = new ValidationContext(model);
        Validator.TryValidateObject(model, context, results, validateAllProperties: true);
        return results;
    }

    [Fact]
    public void SignUpViewModel_EmptyEmail_ShouldFailValidation()
    {
        var model = new SignUpViewModel { Email = "" };
        var results = Validate(model);
        Assert.NotEmpty(results);
    }

    [Fact]
    public void SignUpViewModel_InvalidEmail_ShouldFailValidation()
    {
        var model = new SignUpViewModel { Email = "notanemail" };
        var results = Validate(model);
        Assert.NotEmpty(results);
    }

    [Fact]
    public void SignUpViewModel_ValidEmail_ShouldPassValidation()
    {
        var model = new SignUpViewModel { Email = "test@example.com" };
        var results = Validate(model);
        Assert.Empty(results);
    }

    [Fact]
    public void SetPasswordViewModel_ShortPassword_ShouldFailValidation()
    {
        var model = new SetPasswordViewModel { Email = "test@example.com", Password = "short" };
        var results = Validate(model);
        Assert.NotEmpty(results);
    }

    [Fact]
    public void SetPasswordViewModel_ValidPassword_ShouldPassValidation()
    {
        var model = new SetPasswordViewModel { Email = "test@example.com", Password = "ValidPassword1!" };
        var results = Validate(model);
        Assert.Empty(results);
    }

    [Fact]
    public void AuthResult_Ok_ShouldSucceed()
    {
        var result = AuthResult.Ok();
        Assert.True(result.Succeeded);
    }

    [Fact]
    public void AuthResult_Failed_ShouldContainErrorMessage()
    {
        var result = AuthResult.Failed("Invalid email or password");
        Assert.False(result.Succeeded);
        Assert.Equal("Invalid email or password", result.ErrorMessage);
    }
}