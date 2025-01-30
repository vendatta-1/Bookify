using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Domain.Validation
{
   
        /// <summary>
        /// Represents error codes used in the application.
        /// </summary>
        public enum ErrorCode
        {
            // Authorization & Authentication
            /// <summary>
            /// Access is denied due to unauthorized access.
            /// </summary>
            UnauthorizedAccess = 1000,

            /// <summary>
            /// The provided credentials are invalid.
            /// </summary>
            InvalidCredentials = 1001,

            /// <summary>
            /// The account is locked.
            /// </summary>
            AccountLocked = 1002,

            /// <summary>
            /// The session has expired.
            /// </summary>
            SessionExpired = 1003,

            /// <summary>
            /// The token is invalid.
            /// </summary>
            TokenInvalid = 1004,

            /// <summary>
            /// The token has expired.
            /// </summary>
            TokenExpired = 1005,

            /// <summary>
            /// The token format is invalid.
            /// </summary>
            InvalidTokenFormat = 1006,

            /// <summary>
            /// Insufficient permissions to perform this operation.
            /// </summary>
            InsufficientPermissions = 1007,

            /// <summary>
            /// The provided password is too weak.
            /// </summary>
            PasswordTooWeak = 1008,

            /// <summary>
            /// The account is not activated.
            /// </summary>
            AccountNotActivated = 1009,

            /// <summary>
            /// The account is suspended.
            /// </summary>
            AccountSuspended = 1010,

            /// <summary>
            /// Email verification failed.
            /// </summary>
            EmailVerificationFailed = 1011,

            /// <summary>
            /// Multi-factor authentication is required.
            /// </summary>
            MultiFactorAuthenticationRequired = 1012,

            /// <summary>
            /// An account with this information already exists.
            /// </summary>
            AccountAlreadyExists = 1013,

            /// <summary>
            /// Password reset failed.
            /// </summary>
            PasswordResetFailed = 1014,

            /// <summary>
            /// Authentication service is currently unavailable.
            /// </summary>
            AuthServiceUnavailable = 1015,

            /// <summary>
            /// The refresh token is invalid.
            /// </summary>
            InvalidRefreshToken = 1016,

            /// <summary>
            /// The account has been deactivated.
            /// </summary>
            AccountDeactivated = 1017,

            /// <summary>
            /// The account verification is pending.
            /// </summary>
            AccountVerificationPending = 1018,

            /// <summary>
            /// The provided two-factor code is invalid.
            /// </summary>
            InvalidTwoFactorCode = 1019,

            /// <summary>
            /// Access attempt from an untrusted device.
            /// </summary>
            UntrustedDevice = 1020,

            // CRUD Operations
            /// <summary>
            /// Failed to create the record.
            /// </summary>
            CreateFailed = 2000,

            /// <summary>
            /// Failed to read the record.
            /// </summary>
            ReadFailed = 2001,

            /// <summary>
            /// Failed to update the record.
            /// </summary>
            UpdateFailed = 2002,

            /// <summary>
            /// Failed to delete the record.
            /// </summary>
            DeleteFailed = 2003,

            /// <summary>
            /// The record was not found.
            /// </summary>
            NotFound = 2004,

            /// <summary>
            /// A record with the same identifier already exists.
            /// </summary>
            DuplicateRecord = 2005,

            /// <summary>
            /// The record is currently locked and cannot be modified.
            /// </summary>
            RecordLocked = 2006,

            /// <summary>
            /// The requested operation is not supported.
            /// </summary>
            OperationNotSupported = 2007,

            /// <summary>
            /// Data conflict occurred during the operation.
            /// </summary>
            DataConflict = 2008,

            /// <summary>
            /// Data integrity violation detected.
            /// </summary>
            DataIntegrityViolation = 2009,

            /// <summary>
            /// The record already exists.
            /// </summary>
            RecordAlreadyExists = 2010,

            /// <summary>
            /// No changes were made during the create operation.
            /// </summary>
            CreateNoChanges = 2011,

            /// <summary>
            /// No changes were made during the update operation.
            /// </summary>
            UpdateNoChanges = 2012,

            /// <summary>
            /// No changes were made during the delete operation.
            /// </summary>
            DeleteNoChanges = 2013,

            /// <summary>
            /// Access to read the record is denied.
            /// </summary>
            ReadAccessDenied = 2014,

            /// <summary>
            /// Access to create the record is denied.
            /// </summary>
            CreateAccessDenied = 2015,

            /// <summary>
            /// Access to update the record is denied.
            /// </summary>
            UpdateAccessDenied = 2016,

            /// <summary>
            /// Access to delete the record is denied.
            /// </summary>
            DeleteAccessDenied = 2017,

            /// <summary>
            /// The record has already been deleted.
            /// </summary>
            RecordAlreadyDeleted = 2018,

            /// <summary>
            /// The record was modified by another process.
            /// </summary>
            ConcurrentModification = 2019,

            // Data Validation
            /// <summary>
            /// Data validation failed.
            /// </summary>
            ValidationFailed = 3000,

            /// <summary>
            /// The data format is invalid.
            /// </summary>
            DataFormatInvalid = 3001,

            /// <summary>
            /// A required field is missing.
            /// </summary>
            RequiredFieldMissing = 3002,

            /// <summary>
            /// The field exceeds the maximum length allowed.
            /// </summary>
            MaxLengthExceeded = 3003,

            /// <summary>
            /// The field does not meet the minimum length requirement.
            /// </summary>
            MinLengthRequired = 3004,

            /// <summary>
            /// The email address format is invalid.
            /// </summary>
            InvalidEmailFormat = 3005,

            /// <summary>
            /// The phone number format is invalid.
            /// </summary>
            InvalidPhoneNumber = 3006,

            /// <summary>
            /// The value is out of the allowable range.
            /// </summary>
            ValueOutOfRange = 3007,

            /// <summary>
            /// The data type is not supported.
            /// </summary>
            UnsupportedDataType = 3008,

            /// <summary>
            /// The date format is invalid.
            /// </summary>
            InvalidDateFormat = 3009,

            /// <summary>
            /// The currency format is invalid.
            /// </summary>
            InvalidCurrencyFormat = 3010,

            /// <summary>
            /// The postal code format is invalid.
            /// </summary>
            InvalidPostalCode = 3011,

            /// <summary>
            /// The specified gender is invalid.
            /// </summary>
            InvalidGender = 3012,

            /// <summary>
            /// The file type is not supported.
            /// </summary>
            UnsupportedFileType = 3013,

            /// <summary>
            /// The field value is too short.
            /// </summary>
            FieldTooShort = 3014,

            /// <summary>
            /// The field value is too long.
            /// </summary>
            FieldTooLong = 3015,

            /// <summary>
            /// The age provided is invalid.
            /// </summary>
            InvalidAge = 3016,

            /// <summary>
            /// The date is out of the allowable range.
            /// </summary>
            DateOutOfRange = 3017,

            /// <summary>
            /// The IP address format is invalid.
            /// </summary>
            InvalidIPAddress = 3018,

            // Business Logic
            /// <summary>
            /// The operation is not allowed.
            /// </summary>
            OperationNotAllowed = 4000,

            /// <summary>
            /// Insufficient funds for the operation.
            /// </summary>
            InsufficientFunds = 4001,

            /// <summary>
            /// The resource limit has been exceeded.
            /// </summary>
            ResourceLimitExceeded = 4002,

            /// <summary>
            /// A business rule has been violated.
            /// </summary>
            BusinessRuleViolation = 4003,

            /// <summary>
            /// The requested resource is not available.
            /// </summary>
            ResourceNotAvailable = 4004,

            /// <summary>
            /// The operation exceeds the allowed quota.
            /// </summary>
            ExceedsQuota = 4005,

            /// <summary>
            /// The rate limit for the operation has been exceeded.
            /// </summary>
            RateLimitExceeded = 4006,

            /// <summary>
            /// The discount code is invalid.
            /// </summary>
            InvalidDiscountCode = 4007,

            /// <summary>
            /// The subscription has expired.
            /// </summary>
            SubscriptionExpired = 4008,

            /// <summary>
            /// The requested feature is not enabled.
            /// </summary>
            FeatureNotEnabled = 4009,

            /// <summary>
            /// A premium feature is required for this operation.
            /// </summary>
            PremiumFeatureRequired = 4010,

            /// <summary>
            /// The order is in an invalid state.
            /// </summary>
            InvalidOrderState = 4011,

            /// <summary>
            /// The product is out of stock.
            /// </summary>
            ProductOutOfStock = 4012,

            /// <summary>
            /// The service is currently unavailable.
            /// </summary>
            ServiceUnavailable = 4013,

            /// <summary>
            /// Payment processing failed.
            /// </summary>
            PaymentFailed = 4014,

            /// <summary>
            /// The price does not match the expected value.
            /// </summary>
            PriceMismatch = 4015,

            /// <summary>
            /// A contract violation has occurred.
            /// </summary>
            ContractViolation = 4016,

            /// <summary>
            /// The customer record was not found.
            /// </summary>
            CustomerNotFound = 4017,

            // Math Operations
            /// <summary>
            /// Attempted division by zero.
            /// </summary>
            DivisionByZero = 6000,

            /// <summary>
            /// A mathematical overflow occurred.
            /// </summary>
            Overflow = 6001,

            /// <summary>
            /// A mathematical underflow occurred.
            /// </summary>
            Underflow = 6002,

            /// <summary>
            /// An error occurred during calculation.
            /// </summary>
            CalculationError = 6003,

            /// <summary>
            /// The operation is not valid.
            /// </summary>
            InvalidOperation = 6004,

            /// <summary>
            /// Loss of precision during calculation.
            /// </summary>
            PrecisionLoss = 6005,

            /// <summary>
            /// The mathematical operation is not supported.
            /// </summary>
            UnsupportedMathOperation = 6006,

            /// <summary>
            /// The rounding operation is invalid.
            /// </summary>
            InvalidRounding = 6007,

            /// <summary>
            /// Complex numbers are not supported.
            /// </summary>
            ComplexNumberNotSupported = 6008,

            /// <summary>
            /// Error occurred during decimal conversion.
            /// </summary>
            DecimalConversionError = 6009,

            /// <summary>
            /// An error occurred with floating point operations.
            /// </summary>
            FloatingPointError = 6010,

            /// <summary>
            /// Attempted to take the square root of a negative number.
            /// </summary>
            SquareRootNegative = 6011,

            /// <summary>
            /// Attempted to compute the logarithm of a negative number.
            /// </summary>
            LogarithmNegative = 6012,

            /// <summary>
            /// An error occurred during exponentiation.
            /// </summary>
            ExponentiationError = 6013,

            /// <summary>
            /// The matrix operation is invalid.
            /// </summary>
            InvalidMatrixOperation = 6014,

            /// <summary>
            /// An error occurred during statistical calculations.
            /// </summary>
            StatisticalCalculationError = 6015,

            // File Operations
            /// <summary>
            /// The file was not found.
            /// </summary>
            FileNotFound = 7000,

            /// <summary>
            /// Access to the file is denied.
            /// </summary>
            FileAccessDenied = 7001,

            /// <summary>
            /// The file format is not supported.
            /// </summary>
            FileFormatUnsupported = 7002,

            /// <summary>
            /// An error occurred while reading the file.
            /// </summary>
            FileReadError = 7003,

            /// <summary>
            /// An error occurred while writing to the file.
            /// </summary>
            FileWriteError = 7004,

            /// <summary>
            /// The file upload failed.
            /// </summary>
            FileUploadFailed = 7005,

            /// <summary>
            /// The file size exceeds the allowable limit.
            /// </summary>
            FileSizeExceeded = 7006,

            /// <summary>
            /// The file is corrupted.
            /// </summary>
            FileCorrupted = 7007,

            /// <summary>
            /// A file with the same name already exists.
            /// </summary>
            FileAlreadyExists = 7008,

            /// <summary>
            /// The file download failed.
            /// </summary>
            FileDownloadFailed = 7009,

            /// <summary>
            /// The file deletion failed.
            /// </summary>
            FileDeletionFailed = 7010,

            /// <summary>
            /// The file is locked and cannot be accessed.
            /// </summary>
            FileLockError = 7011,

            /// <summary>
            /// Insufficient permissions to access the file.
            /// </summary>
            FilePermissionError = 7012,

            // Network Errors
            /// <summary>
            /// The network is unavailable.
            /// </summary>
            NetworkUnavailable = 8000,

            /// <summary>
            /// The connection has timed out.
            /// </summary>
            ConnectionTimeout = 8001,

            /// <summary>
            /// The connection was refused.
            /// </summary>
            ConnectionRefused = 8002,

            /// <summary>
            /// A network error occurred.
            /// </summary>
            NetworkError = 8003,

            /// <summary>
            /// The host could not be found.
            /// </summary>
            HostNotFound = 8004,

            /// <summary>
            /// A protocol error occurred.
            /// </summary>
            ProtocolError = 8005,

            /// <summary>
            /// The requested service is unavailable.
            /// </summary>
            NetServiceUnavailable = 8006,

            /// <summary>
            /// The request is invalid.
            /// </summary>
            InvalidRequest = 8007,

            /// <summary>
            /// There is a network configuration error.
            /// </summary>
            NetworkConfigurationError = 8008,

            /// <summary>
            /// DNS resolution failed.
            /// </summary>
            DNSResolutionFailed = 8009,

            /// <summary>
            /// The SSL handshake failed.
            /// </summary>
            SSLHandshakeFailed = 8010,

            /// <summary>
            /// The connection was reset.
            /// </summary>
            ConnectionReset = 8011,

            // Security
            /// <summary>
            /// Encryption failed.
            /// </summary>
            EncryptionFailed = 9000,

            /// <summary>
            /// Decryption failed.
            /// </summary>
            DecryptionFailed = 9001,

            /// <summary>
            /// A security violation has occurred.
            /// </summary>
            SecurityViolation = 9002,

            /// <summary>
            /// The certificate is invalid.
            /// </summary>
            InvalidCertificate = 9003,

            /// <summary>
            /// Unauthorized access attempt detected.
            /// </summary>
            UnauthorizedAccessAttempt = 9004,

            /// <summary>
            /// A data breach has been detected.
            /// </summary>
            DataBreach = 9005,

            /// <summary>
            /// There is an error with the security protocol.
            /// </summary>
            SecurityProtocolError = 9006,

            /// <summary>
            /// Access is denied.
            /// </summary>
            AccessDenied = 9007,

            /// <summary>
            /// Security measures are insufficient.
            /// </summary>
            InsufficientSecurity = 9008,

            /// <summary>
            /// An authentication error occurred.
            /// </summary>
            AuthenticationError = 9009,

            /// <summary>
            /// Access from an unauthorized IP address.
            /// </summary>
            UnauthorizedIP = 9010,

            /// <summary>
            /// The security key does not match.
            /// </summary>
            SecurityKeyMismatch = 9011,

            // General Errors
            /// <summary>
            /// An unexpected error occurred.
            /// </summary>
            GeneralError = 9999,

            /// <summary>
            /// The operation failed.
            /// </summary>
            OperationFailed = 9998,

            /// <summary>
            /// An unexpected error occurred.
            /// </summary>
            UnexpectedError = 9997,

            /// <summary>
            /// An unknown error occurred.
            /// </summary>
            UnknownError = 9996,

            /// <summary>
            /// The requested feature is not yet implemented.
            /// </summary>
            FeatureNotImplemented = 9995,

            /// <summary>
            /// The feature is deprecated and no longer supported.
            /// </summary>
            DeprecatedFeature = 9994,

            /// <summary>
            /// The service is not available at this time.
            /// </summary>
            ServiceNotAvailable = 9993,

            /// <summary>
            /// The operation timed out.
            /// </summary>
            TimeoutError = 9992,

            /// <summary>
            /// The requested resource is unavailable.
            /// </summary>
            ResourceUnavailable = 9991,

            /// <summary>
            /// The request was canceled.
            /// </summary>
            RequestCanceled = 9990,

            /// <summary>
            /// An internal server error occurred.
            /// </summary>
            InternalServerError = 9989,

            /// <summary>
            /// The service is temporarily unavailable, please retry.
            /// </summary>
            ServiceUnavailableRetry = 9988,

            /// <summary>
            /// the argument that has been passed is null
            /// </summary>
            ArgumentNull = 1000,

            /// <summary>
            /// the value of the object is null
            /// </summary>
            NullValue = 1001

        }
    
}
