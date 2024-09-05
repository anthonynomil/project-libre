using Application.Interface;
using Database.Abstract;
using Entities;
using Infrastructure.Database;

namespace Database.Repository;

public sealed class CountryRepository(ProjetLibreContext context)
    : BaseRepository<Country>(context),
        ICountryRepository;
