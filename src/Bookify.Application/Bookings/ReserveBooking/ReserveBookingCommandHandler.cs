using Bookify.Application.Abstractions.Clock;
using Bookify.Application.Abstractions.Exceptions;
using Bookify.Application.Abstractions.Messaging;
using Bookify.Domain.Abstractions;
using Bookify.Domain.Apartments;
using Bookify.Domain.Bookings;
using Bookify.Domain.Users;
using Bookify.Domain.Validation;

namespace Bookify.Application.Bookings.ReserveBooking
{
    public class ReserveBookingCommandHandler
        : ICommandHandler<ReserveBookingCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly PricingService _pricingService;
        private readonly IDateTimeProvider _dateTimeProvider;
        public ReserveBookingCommandHandler(IUserRepository userRepository, IApartmentRepository apartmentRepository, IBookingRepository bookingRepository, IUnitOfWork unitOfWork, PricingService pricingService,
            IDateTimeProvider dateTimeProvider)
        {
            _userRepository = userRepository;
            _apartmentRepository = apartmentRepository;
            _bookingRepository = bookingRepository;
            _unitOfWork = unitOfWork;
            _pricingService = pricingService;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<Result<Guid>> Handle(ReserveBookingCommand request, CancellationToken cancellationToken)
        {
            var apartment = await _apartmentRepository.GetByIdAsync(request.ApartmentId, cancellationToken);
            if (apartment is null)
            {
                return Result.Failure<Guid>(new Error(ErrorCode.NotFound.ToString(),
                    ErrorMessages.GetMessage(ErrorCode.NotFound)));
            }

            var user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);
            if (user is null)
            {
                return Result.Failure<Guid>(new Error(ErrorCode.NotFound.ToString(),
                    "The user is not register yet in the system"));

            }


            var duration = DateRange.Create(request.StartDate, request.EndDate);

            if (await _bookingRepository.IsOverlappingAsync(apartment, duration, cancellationToken))
            {
                return Result.Failure<Guid>(new Error(ErrorCode.RecordAlreadyExists.ToString(),
                    "U try to overlap an existing Booking"));
            }

            try
            {

                var booking = Booking.Reserve(
                    apartment,
                    request.UserId,
                    duration,
                    _dateTimeProvider.UtcNow,
                    _pricingService);

                //this cause a race condition problem by using optimistic looking to the database

                await _unitOfWork.SaveChangesAsync(cancellationToken);
                return booking.Id;

            }
            catch (ConcurrencyException e)
            {
                return Result.Failure<Guid>(BookingErrors.Overlap);
            }


        }
    }
}
