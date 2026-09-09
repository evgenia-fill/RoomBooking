using Microsoft.Extensions.Logging;
using RoomBooking.Contracts.Booking;
using RoomBooking.Domain.Booking;

namespace RoomBooking.Application;

public class BookingsService
{
    private readonly IBookingRepository _bookingRepository;
    private readonly ILogger<BookingsService> _logger;

    public BookingsService(IBookingRepository bookingRepository, ILogger<BookingsService> logger)
    {
        _bookingRepository = bookingRepository;
        _logger = logger;
    }

    public async Task<Booking> CreateAsync(CreateBookingDto dto, CancellationToken cancellationToken)
    {
        var booking = new Booking(dto.Title, dto.Description, dto.UserId, dto.RoomId, dto.StartTime, dto.EndTime);
        _logger.LogInformation("Booking created with Id: {BookingId}", booking.Id);
        return await _bookingRepository.AddAsync(booking, cancellationToken);
    }

    public async Task CancelBookingAsync(int bookingId, CancellationToken cancellationToken)
    {
        var booking = await _bookingRepository.GetByIdAsync(bookingId, cancellationToken);
        if (booking == null) throw new KeyNotFoundException("Booking not found");

        booking.Cancel();
        await _bookingRepository.UpdateAsync(booking, cancellationToken);

        _logger.LogInformation("Booking canceled with Id: {BookingId}", booking.Id);
    }

    public async Task<Booking?> GetByIdAsync(int bookingId, CancellationToken cancellationToken)
    {
        return await _bookingRepository.GetByIdAsync(bookingId, cancellationToken);
    }

    public async Task<List<Booking>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _bookingRepository.GetAllAsync(cancellationToken);
    }

    public async Task<List<Booking>> GetByRoomIdAsync(int roomId,
        CancellationToken cancellationToken)
    {
        return await _bookingRepository.GetByRoomIdAsync(roomId, cancellationToken);
    }

    public async Task<List<Booking>> GetByUserIdAsync(Guid userId,
        CancellationToken cancellationToken)
    {
        return await _bookingRepository.GetByUserIdAsync(userId, cancellationToken);
    }

    public async Task ChangeBookingTitleAsync(int bookingId, ChangeBookingTitleDto dto,
        CancellationToken cancellationToken)
    {
        var booking = await _bookingRepository.GetByIdAsync(bookingId, cancellationToken);
        if (booking == null) throw new KeyNotFoundException("Booking not found");

        booking.ChangeTitle(dto.Title);
        await _bookingRepository.UpdateAsync(booking, cancellationToken);

        _logger.LogInformation("Booking updated (changed title) with Id: {BookingId}", booking.Id);
    }

    public async Task ChangeBookingDescriptionAsync(int bookingId,
        ChangeBookingDescriptionDto dto,
        CancellationToken cancellationToken)
    {
        var booking = await _bookingRepository.GetByIdAsync(bookingId, cancellationToken);
        if (booking == null) throw new KeyNotFoundException("Booking not found");

        booking.ChangeDescription(dto.Description);
        await _bookingRepository.UpdateAsync(booking, cancellationToken);

        _logger.LogInformation("Booking updated (changed description) with Id: {BookingId}", booking.Id);
    }

    public async Task ChangeBookingScheduleAsync(int bookingId,
        ChangeBookingScheduleDto dto,
        CancellationToken cancellationToken)
    {
        var booking = await _bookingRepository.GetByIdAsync(bookingId, cancellationToken);
        if (booking == null) throw new KeyNotFoundException("Booking not found");

        booking.ChangeSchedule(dto.StartTime, dto.EndTime);
        await _bookingRepository.UpdateAsync(booking, cancellationToken);

        _logger.LogInformation("Booking updated (changed schedule) with Id: {BookingId}", booking.Id);
    }

    public async Task ChangeBookingRoomAsync(int bookingId, ChangeBookingRoomDto dto,
        CancellationToken cancellationToken)
    {
        var booking = await _bookingRepository.GetByIdAsync(bookingId, cancellationToken);
        if (booking == null) throw new KeyNotFoundException("Booking not found");

        booking.ChangeRoom(dto.RoomId);
        await _bookingRepository.UpdateAsync(booking, cancellationToken);

        _logger.LogInformation("Booking updated (changed room) with Id: {BookingId}", booking.Id);
    }
}