using Application.Interface;
using Database.Abstract;
using Entities.Abstract;
using Infrastructure.Database;

namespace Database.Repository;

public sealed class PersonRepository(ProjetLibreContext context)
    : BaseRepository<Person>(context),
        IPersonRepository;
