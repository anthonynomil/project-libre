using Application.Interface;
using Database.Abstract;
using Entities;
using Infrastructure.Database;

namespace Database.Repository;

public sealed class ContactInformationRepository(ProjetLibreContext context)
    : BaseRepository<ContactInformation>(context),
        IContactInformationRepository;
