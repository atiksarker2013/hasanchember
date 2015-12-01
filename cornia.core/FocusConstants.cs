using System;
using System.Globalization;

namespace cornia.core
{
    public static class FocusConstants
    {
        public enum FocusResultCode
        {
            Success = 1000,
            InvalidSecurityKey = 1001,
            DataNotFound = 1002,
            Duplicate = 1003,
            AppLogicError = 1004,
            Exception = 1005,
            UserTypeNameEmpty = 1006,
            UserTypeCodeEmpty = 1007,
            NameEmpty = 1008,
            CodeEmpty = 1009,
            FluentValidation = 1010,
            GroupCompanyNameEmpty = 1011,
            GroupCompanyCodeEmpty = 1012,
            PaymentTypeNameEmpty = 1013,
            PaymentTypeCodeEmpty = 1014,
            CurrencyNameEmpty = 1015,
            CurrencyCodeEmpty = 1016,
            EmployeeTypeNameEmpty = 1017,
            EmployeeTypeCodeEmpty = 1018,
            CustomerNameEmpty = 1019,
            CustomerCodeEmpty = 1020,
            FactoryNameEmpty = 1021,
            FactoryCodeEmpty = 1022,
            PersonTypeNameEmpty = 1023,
            PersonTypeCodeEmpty = 1024,
            EmployeeNameEmpty = 1025,
            EmployeeCodeEmpty = 1026,
            TitleNameEmpty = 1027,
            TitleCodeEmpty = 1028,
            PersonalNameEmpty = 1029,
            PersonalCodeEmpty = 1030,
            MemberNotExist = 1031,
            MemberIsNotActive = 1032,
            InvalidEmail = 1033,
            MailSend = 1034,
            EmailOrPasswordEmpty = 1035,
            InvalidPassword = 1036,
            EmailAddressIsNull = 1037,
            DuplicateUser = 1038,
            UserExistUnderThisGroup = 1039,
            UserExistUnderThisCustomer = 1040,
            UserExistUnderThisFactory = 1041,
            UserExistUnderThisPerson = 1042,
            MessageTypeNameEmpty = 1043,
            MeasurementTypeCodeEmpty = 1044,
            MeasurementTypeNameEmpty = 1045,
            MeasurementTypeAbbreviationEmpty = 1046,
            OrderTypeCodeEmpty = 1047,
            OrderTypeNameEmpty = 1048,
            TitleEmpty = 1049,
            PasswordEmpty = 1050,
            PasswordChangeSuccess = 1051,
            PINEmpty = 1052,
            ChangePassword = 1053,
            OldPasswordEmpty = 1054,
            NewPasswordEmpty = 1055,
            ConfirmPasswordEmpty = 1056,
            UserTypePermissionExist = 1057,
            UserHasNotAddPermission = 1058,
            UserHasNoUpdatePermission = 1059,
            PermissionNameAlreadyExist = 1060,
            PermissionIdAlreadyExist = 1061,
            InvalidPIN = 1062,
            NewAndConfirmPasswordMissmatch = 1063,
            InvalidOldPassword = 1064,
            NewAndConfirmPINMissmatch = 1065,
            PINChangeSuccess = 1066,
            UserHasNoDeletePermission = 1067,
            InvalidOldPIN = 1068,
            OldPINEmpty = 1069,
            NewPINEmpty = 1070,
            ConfirmPINEmpty = 1071,
            InvalidPasswordFormat = 1072,
            InvalidPinFormat = 1072
        }


        public const string InvalidSecurityKeyErrorMsg = "Your application not allowed. Please uninstall your application and install again to your device.";
        public const string EnceptionErrorMsg = "System Error. Please try again.";
        public const string DateFormat101 = "yyyy.MM.dd HH:mm";
        public const string DateFormat102 = "dd/MM/yyyy HH:mm";
        public const string DateFormat103 = "MM/dd/yyyy hh:mm tt";

        public static string[] formats = new string[]
        {
            "MM/dd/yyyy HH:mm:ss tt",
            "MM/dd/yyyy HH:mm:ss",
            "M/dd/yyyy H:mm:ss tt",
            "M/dd/yyyy H:mm:ss"   ,
            "MM/dd/yyyy hh:mm tt"
        };
        public static DateTime ParseDate(string input)
        {
            return DateTime.ParseExact(input, formats, CultureInfo.InvariantCulture, DateTimeStyles.None);
        }
    }
}
