namespace Application.Constants
{
    public static class StaffMessage
    {
        public const string FirstNameRequired = "First name is required";
        public const string FirstNameMaxLength = "First name cannot be longer than 30 characters";
        public const string LastNameRequired = "Last name is required";
        public const string LastNameMaxLength = "Last name cannot be longer than 30 characters";
        public const string EmailRequired = "Email is required";
        public const string EmailMaxLength = "Email cannot be longer than 50 characters";
        public const string EmailInvalid = "Email is invalid";
        public const string PhoneRequired = "Phone is required";
        public const string PhoneMaxLength = "Phone cannot be longer than 30 characters";
        public const string DateOfBirthRequired = "Date of birth is required";
        public const string AddressLine1Required = "Address line 1 is required";
        public const string AddressLine1MaxLength = "Address line 1 cannot be longer than 150 characters";
        public const string CityRequired = "City is required";
        public const string CityMaxLength = "City cannot be longer than 50 characters";
        public const string CountryRequired = "Country is required";
        public const string CountryMaxLength = "Country cannot be longer than 100 characters";
        public const string ProvinceRequired = "Province is required";
        public const string ProvinceMaxLength = "Province cannot be longer than 50 characters";

        public const string StaffNotFoundById = "Staff not found by ID.";
        public const string StaffNotFoundByCity = "Staff not found by city.";
        public const string StaffListIsEmpty = "Staff list is empty.";
        public const string StaffExistsByEmail = "Staff already exists by email.";
    }
}
