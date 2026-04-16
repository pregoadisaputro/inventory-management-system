public interface IUserInput
{
    string GetValidateStringInput(string prompt);
    int GetValidateIntInput(string prompt);
    decimal GetValidateDecimalInput(string prompt);
    bool IsProductEmpty();
}
