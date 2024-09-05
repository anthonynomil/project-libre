using Application.Interface;
using Database.Abstract;
using Entities;
using Infrastructure.Database;

namespace Database.Repository;

public sealed class AddressRepository(ProjetLibreContext context)
    : BaseRepository<Address>(context),
        IAddressRepository;
