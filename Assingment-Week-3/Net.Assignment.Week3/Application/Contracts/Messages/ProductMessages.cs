namespace Application.Contracts.Messages;

public static class ProductMessages
{
    public const string ProductAlreadyExistsByName = "Product with name already exists";
    public const string ProductNotFoundById = "Product with id not found";
    public const string ProductNotFoundByName = "Product with name not found";
    public const string ProductListIsEmpty = "Product list is empty";
    
    public const string ProductCategoryIdIsRequired = "Product category id is required";
    public const string ProductNameIsRequired = "Product name is required";
    public const string ProductNameMustBeLessThan30Characters = "Product name must be less than 30 characters";
    public const string ProductUrlIsRequired = "Product url is required";
    public const string ProductUrlMustBeLessThan30Characters = "Product url must be less than 30 characters";
    public const string ProductTagIsRequired = "Product tag is required";
    public const string ProductTagMustBeLessThan100Characters = "Product tag must be less than 100 characters";
}