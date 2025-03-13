using Zoo_management.enums;

namespace Zoo_management.Utility;
public class InputValidations {

    public static bool ValidateClassification(string classification) {
        return Enum.IsDefined(typeof(Classification), classification);
    }

    public static bool ValidateSex(string sex) {
        return Enum.IsDefined(typeof(Sex), sex);
    }

    public static bool ValidateStatus(string status) {
        return Enum.IsDefined(typeof(Status), status);
    }
}