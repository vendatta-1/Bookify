namespace Bookify.Domain.Validation
{

    public static class ErrorMessages
    {
        /// <summary>
        /// Provides error messages for the given error codes.
        /// </summary>
        private static readonly Lazy<IDictionary<int, string>> _errorMessages = new Lazy<IDictionary<int, string>>(() =>
        {
            var messages = new Dictionary<int, string>
            {
                // Authorization & Authentication
                { (int)ErrorCode.UnauthorizedAccess, "Access is denied due to unauthorized access." },
                { (int)ErrorCode.InvalidCredentials, "The provided credentials are invalid." },
                { (int)ErrorCode.AccountLocked, "The account is locked." },
                { (int)ErrorCode.SessionExpired, "The session has expired." },
                { (int)ErrorCode.TokenInvalid, "The token is invalid." },
                { (int)ErrorCode.TokenExpired, "The token has expired." },
                { (int)ErrorCode.InvalidTokenFormat, "The token format is invalid." },
                { (int)ErrorCode.InsufficientPermissions, "Insufficient permissions to perform this operation." },
                { (int)ErrorCode.PasswordTooWeak, "The provided password is too weak." },
                { (int)ErrorCode.AccountNotActivated, "The account is not activated." },
                { (int)ErrorCode.AccountSuspended, "The account is suspended." },
                { (int)ErrorCode.EmailVerificationFailed, "Email verification failed." },
                { (int)ErrorCode.MultiFactorAuthenticationRequired, "Multi-factor authentication is required." },
                { (int)ErrorCode.AccountAlreadyExists, "An account with this information already exists." },
                { (int)ErrorCode.PasswordResetFailed, "Password reset failed." },
                { (int)ErrorCode.AuthServiceUnavailable, "Authentication service is currently unavailable." },
                { (int)ErrorCode.InvalidRefreshToken, "The refresh token is invalid." },
                { (int)ErrorCode.AccountDeactivated, "The account has been deactivated." },
                { (int)ErrorCode.AccountVerificationPending, "The account verification is pending." },
                { (int)ErrorCode.InvalidTwoFactorCode, "The provided two-factor code is invalid." },
                { (int)ErrorCode.UntrustedDevice, "Access attempt from an untrusted device." },

                // CRUD Operations
                { (int)ErrorCode.CreateFailed, "Failed to create the record." },
                { (int)ErrorCode.ReadFailed, "Failed to read the record." },
                { (int)ErrorCode.UpdateFailed, "Failed to update the record." },
                { (int)ErrorCode.DeleteFailed, "Failed to delete the record." },
                { (int)ErrorCode.NotFound, "The record was not found." },
                { (int)ErrorCode.DuplicateRecord, "A record with the same identifier already exists." },
                { (int)ErrorCode.RecordLocked, "The record is currently locked and cannot be modified." },
                { (int)ErrorCode.OperationNotSupported, "The requested operation is not supported." },
                { (int)ErrorCode.DataConflict, "Data conflict occurred during the operation." },
                { (int)ErrorCode.DataIntegrityViolation, "Data integrity violation detected." },
                { (int)ErrorCode.RecordAlreadyExists, "The record already exists." },
                { (int)ErrorCode.CreateNoChanges, "No changes were made during the create operation." },
                { (int)ErrorCode.UpdateNoChanges, "No changes were made during the update operation." },
                { (int)ErrorCode.DeleteNoChanges, "No changes were made during the delete operation." },
                { (int)ErrorCode.ReadAccessDenied, "Access to read the record is denied." },
                { (int)ErrorCode.CreateAccessDenied, "Access to create the record is denied." },
                { (int)ErrorCode.UpdateAccessDenied, "Access to update the record is denied." },
                { (int)ErrorCode.DeleteAccessDenied, "Access to delete the record is denied." },
                { (int)ErrorCode.RecordAlreadyDeleted, "The record has already been deleted." },
                { (int)ErrorCode.ConcurrentModification, "The record was modified by another process." },

                // Data Validation
                { (int)ErrorCode.ValidationFailed, "Data validation failed." },
                { (int)ErrorCode.DataFormatInvalid, "The data format is invalid." },
                { (int)ErrorCode.RequiredFieldMissing, "A required field is missing." },
                { (int)ErrorCode.MaxLengthExceeded, "The field exceeds the maximum length allowed." },
                { (int)ErrorCode.MinLengthRequired, "The field does not meet the minimum length requirement." },
                { (int)ErrorCode.InvalidEmailFormat, "The email address format is invalid." },
                { (int)ErrorCode.InvalidPhoneNumber, "The phone number format is invalid." },
                { (int)ErrorCode.ValueOutOfRange, "The value is out of the allowable range." },
                { (int)ErrorCode.UnsupportedDataType, "The data type is not supported." },
                { (int)ErrorCode.InvalidDateFormat, "The date format is invalid." },
                { (int)ErrorCode.InvalidCurrencyFormat, "The currency format is invalid." },
                { (int)ErrorCode.InvalidPostalCode, "The postal code format is invalid." },
                { (int)ErrorCode.InvalidGender, "The specified gender is invalid." },
                { (int)ErrorCode.UnsupportedFileType, "The file type is not supported." },
                { (int)ErrorCode.FieldTooShort, "The field value is too short." },
                { (int)ErrorCode.FieldTooLong, "The field value is too long." },
                { (int)ErrorCode.InvalidAge, "The age provided is invalid." },
                { (int)ErrorCode.DateOutOfRange, "The date is out of the allowable range." },
                { (int)ErrorCode.InvalidIPAddress, "The IP address format is invalid." },

                // Business Logic
                { (int)ErrorCode.OperationNotAllowed, "The operation is not allowed." },
                { (int)ErrorCode.InsufficientFunds, "Insufficient funds for the operation." },
                { (int)ErrorCode.ResourceLimitExceeded, "The resource limit has been exceeded." },
                { (int)ErrorCode.BusinessRuleViolation, "A business rule has been violated." },
                { (int)ErrorCode.ResourceNotAvailable, "The requested resource is not available." },
                { (int)ErrorCode.ExceedsQuota, "The operation exceeds the allowed quota." },
                { (int)ErrorCode.RateLimitExceeded, "The rate limit for the operation has been exceeded." },
                { (int)ErrorCode.InvalidDiscountCode, "The discount code is invalid." },
                { (int)ErrorCode.SubscriptionExpired, "The subscription has expired." },
                { (int)ErrorCode.FeatureNotEnabled, "The requested feature is not enabled." },
                { (int)ErrorCode.PremiumFeatureRequired, "A premium feature is required for this operation." },
                { (int)ErrorCode.InvalidOrderState, "The order is in an invalid state." },
                { (int)ErrorCode.ProductOutOfStock, "The product is out of stock." },
                { (int)ErrorCode.ServiceUnavailable, "The service is currently unavailable." },
                { (int)ErrorCode.PaymentFailed, "Payment processing failed." },
                { (int)ErrorCode.PriceMismatch, "The price does not match the expected value." },
                { (int)ErrorCode.ContractViolation, "A contract violation has occurred." },
                { (int)ErrorCode.CustomerNotFound, "The customer record was not found." },

                // Math Operations
                { (int)ErrorCode.DivisionByZero, "Attempted division by zero." },
                { (int)ErrorCode.Overflow, "A mathematical overflow occurred." },
                { (int)ErrorCode.Underflow, "A mathematical underflow occurred." },
                { (int)ErrorCode.CalculationError, "An error occurred during calculation." },
                { (int)ErrorCode.InvalidOperation, "The operation is not valid." },
                { (int)ErrorCode.PrecisionLoss, "Loss of precision during calculation." },
                { (int)ErrorCode.UnsupportedMathOperation, "The mathematical operation is not supported." },
                { (int)ErrorCode.InvalidRounding, "The rounding operation is invalid." },
                { (int)ErrorCode.ComplexNumberNotSupported, "Complex numbers are not supported." },
                { (int)ErrorCode.DecimalConversionError, "Error occurred during decimal conversion." },
                { (int)ErrorCode.FloatingPointError, "An error occurred with floating point operations." },
                { (int)ErrorCode.SquareRootNegative, "Attempted to take the square root of a negative number." },
                { (int)ErrorCode.LogarithmNegative, "Attempted to compute the logarithm of a negative number." },
                { (int)ErrorCode.ExponentiationError, "An error occurred during exponentiation." },
                { (int)ErrorCode.InvalidMatrixOperation, "The matrix operation is invalid." },
                { (int)ErrorCode.StatisticalCalculationError, "An error occurred during statistical calculations." },

                // File Operations
                { (int)ErrorCode.FileNotFound, "The file was not found." },
                { (int)ErrorCode.FileAccessDenied, "Access to the file is denied." },
                { (int)ErrorCode.FileFormatUnsupported, "The file format is not supported." },
                { (int)ErrorCode.FileReadError, "An error occurred while reading the file." },
                { (int)ErrorCode.FileWriteError, "An error occurred while writing to the file." },
                { (int)ErrorCode.FileUploadFailed, "The file upload failed." },
                { (int)ErrorCode.FileSizeExceeded, "The file size exceeds the allowable limit." },
                { (int)ErrorCode.FileCorrupted, "The file is corrupted." },
                { (int)ErrorCode.FileAlreadyExists, "A file with the same name already exists." },
                { (int)ErrorCode.FileDownloadFailed, "The file download failed." },
                { (int)ErrorCode.FileDeletionFailed, "The file deletion failed." },
                { (int)ErrorCode.FileLockError, "The file is locked and cannot be accessed." },
                { (int)ErrorCode.FilePermissionError, "Insufficient permissions to access the file." },

                // Network Errors
                { (int)ErrorCode.NetworkUnavailable, "The network is unavailable." },
                { (int)ErrorCode.ConnectionTimeout, "The connection has timed out." },
                { (int)ErrorCode.ConnectionRefused, "The connection was refused." },
                { (int)ErrorCode.NetworkError, "A network error occurred." },
                { (int)ErrorCode.HostNotFound, "The host could not be found." },
                { (int)ErrorCode.ProtocolError, "A protocol error occurred." },
                { (int)ErrorCode.NetServiceUnavailable, "The requested service is unavailable." },
                { (int)ErrorCode.InvalidRequest, "The request is invalid." },
                { (int)ErrorCode.NetworkConfigurationError, "There is a network configuration error." },
                { (int)ErrorCode.DNSResolutionFailed, "DNS resolution failed." },
                { (int)ErrorCode.SSLHandshakeFailed, "The SSL handshake failed." },
                { (int)ErrorCode.ConnectionReset, "The connection was reset." },

                // Security
                { (int)ErrorCode.EncryptionFailed, "Encryption failed." },
                { (int)ErrorCode.DecryptionFailed, "Decryption failed." },
                { (int)ErrorCode.SecurityViolation, "A security violation has occurred." },
                { (int)ErrorCode.InvalidCertificate, "The certificate is invalid." },
                { (int)ErrorCode.UnauthorizedAccessAttempt, "Unauthorized access attempt detected." },
                { (int)ErrorCode.DataBreach, "A data breach has been detected." },
                { (int)ErrorCode.SecurityProtocolError, "There is an error with the security protocol." },
                { (int)ErrorCode.AccessDenied, "Access is denied." },
                { (int)ErrorCode.InsufficientSecurity, "Security measures are insufficient." },
                { (int)ErrorCode.AuthenticationError, "An authentication error occurred." },
                { (int)ErrorCode.UnauthorizedIP, "Access from an unauthorized IP address." },
                { (int)ErrorCode.SecurityKeyMismatch, "The security key does not match." },

                // General Errors
                { (int)ErrorCode.GeneralError, "An unexpected error occurred." },
                { (int)ErrorCode.OperationFailed, "The operation failed." },
                { (int)ErrorCode.UnexpectedError, "An unexpected error occurred." },
                { (int)ErrorCode.UnknownError, "An unknown error occurred." },
                { (int)ErrorCode.FeatureNotImplemented, "The requested feature is not yet implemented." },
                { (int)ErrorCode.DeprecatedFeature, "The feature is deprecated and no longer supported." },
                { (int)ErrorCode.ServiceNotAvailable, "The service is not available at this time." },
                { (int)ErrorCode.TimeoutError, "The operation timed out." },
                { (int)ErrorCode.ResourceUnavailable, "The requested resource is unavailable." },
                { (int)ErrorCode.RequestCanceled, "The request was canceled." },
                { (int)ErrorCode.InternalServerError, "An internal server error occurred." },
                { (int)ErrorCode.ServiceUnavailableRetry, "The service is temporarily unavailable, please retry." }
            };

            return messages;
        });

        /// <summary>
        /// Gets the error message associated with an error code.
        /// </summary>
        /// <param name="code">The error code.</param>
        /// <returns>The error message.</returns>
        public static string GetMessage(ErrorCode code)
        {
            return _errorMessages.Value.TryGetValue((int)code, out var message)
                ? message
                : "Unknown error.";
        }

        /// <summary>
        /// Adds a new error message to the dictionary.
        /// </summary>
        /// <param name="code">The error code (can be an integer or ErrorCode).</param>
        /// <param name="message">The error message.</param>
        public static void AddMessage(int code, string message)
        {
            _errorMessages.Value[code] = message;
        }

        /// <summary>
        /// Adds a new error message to the dictionary using an ErrorCode.
        /// </summary>
        /// <param name="code">The ErrorCode.</param>
        /// <param name="message">The error message.</param>
        public static void AddMessage(ErrorCode code, string message)
        {
            _errorMessages.Value[(int)code] = message;
        }
    }
}