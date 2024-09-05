using Application.Interface;
using Database.Abstract;
using Entities;
using Infrastructure.Database;

namespace Database.Repository;

public sealed class BankDetailsRepository(ProjetLibreContext context)
    : BaseRepository<BankDetails>(context),
        IBankDetailsRepository;
