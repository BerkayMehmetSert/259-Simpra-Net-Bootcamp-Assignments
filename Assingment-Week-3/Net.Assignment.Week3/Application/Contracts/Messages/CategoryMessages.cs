namespace Application.Contracts.Messages;

public static class CategoryMessages
{
    public const string CategoryAlreadyExistsByName = "Category with name already exists";
    public const string CategoryNotFoundById = "Category with id not found";
    public const string CategoryNotFoundByName = "Category with name not found";
    public const string CategoryListIsEmpty = "Category list is empty";

    public const string CategoryNameIsRequired = "Category name is required";
    public const string CategoryNameMustBeLessThan30Characters = "Category name must be less than 30 characters";
    public const string CategoryOrderIsRequired = "Category order is required";
}