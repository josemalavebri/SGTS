using SGTS.Models.Query.DTOs;
using SGTS.Models.Ticket.Enums;

namespace SGTS.Models.Ticket.Dtos;

public class TicketQueryRequestDTO
    : QueryRequestDTO<TicketOrderColumn, TicketFilterDto>
{
}