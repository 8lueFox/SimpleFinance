using MediatR;
using SimpleFinance.Application.DTO;

namespace SimpleFinance.Application.Queries.WalletQueries;

public record SearchWallet(string SearchPhrase) : IRequest<WalletDto>;