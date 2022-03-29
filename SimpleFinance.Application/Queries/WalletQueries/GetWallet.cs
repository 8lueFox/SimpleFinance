using MediatR;
using SimpleFinance.Application.DTO;

namespace SimpleFinance.Application.Queries.WalletQueries;

public record GetWallet(Guid id) : IRequest<WalletDto>;
