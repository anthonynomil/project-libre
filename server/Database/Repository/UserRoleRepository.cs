using Application.Interface;
using Database.Abstract;
using Entities;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Database.Repository;

public sealed class UserRoleRepository(ProjetLibreContext context)
    : BaseRepository<UserRole>(context),
        IUserRoleRepository;
