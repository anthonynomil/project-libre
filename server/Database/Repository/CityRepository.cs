using Application.Interface;
using Database.Abstract;
using Entities;
using Infrastructure.Database;

namespace Database.Repository;

public sealed class CityRepository(ProjetLibreContext context)
    : BaseRepository<City>(context),
        ICityRepository;
