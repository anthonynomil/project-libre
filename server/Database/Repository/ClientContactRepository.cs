using Application.Interface;
using Database.Abstract;
using Entities;
using Infrastructure.Database;

namespace Database.Repository;

public sealed class ClientContactRepository(ProjetLibreContext context)
    : BaseRepository<ClientContact>(context),
        IClientContactRepository;
