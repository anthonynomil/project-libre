using Application.Interface;
using Entities;
using Entities.Enum;
using Models;

namespace Application.Service;

public class InitializationApplicationService(
    IDataInfrastructureService dataInfrastructureService,
    ICompanyRepository companyRepository,
    ICityRepository cityRepository,
    ICountryRepository countryRepository,
    IUserRepository userRepository,
    IUserRoleRepository userRoleRepository
) : IInitializationApplicationService
{
    private const string CountriesEndpoint = "https://restcountries.com/v3.1/all";

    public async Task Init()
    {
        await FetchCountries();
        await CreateUserRoles();
        await CreateUsers();
        await CreateCities();
        await CreateCompanies();
    }

    /// <summary>
    /// Fetch countries to the corresponding external API and save them to database when needed
    /// </summary>
    /// <returns>Result of the fetch task, containing an enumerable of Country</returns>
    private async Task FetchCountries()
    {
        var checkCountries = await countryRepository.GetPagedListAsync(
            new CompanyDtoPagedListParameters(1, null)
        );
        if (checkCountries.Count > 0)
            return;

        var data = await dataInfrastructureService.FetchData<ICollection<ThirdPartyCountryDto>>(
            CountriesEndpoint
        );

        var countries = data!.Select(
            thirdPartyCountryDto =>
                new Country(thirdPartyCountryDto.Name.Common, thirdPartyCountryDto.Flags.Svg)
        );

        await countryRepository.CreateBatchAndSaveAsync(countries);
    }

    public class ThirdPartyCountryDto
    {
        public ThirdPartyCountryDtoName Name { get; init; }
        public ThirdPartyCountryDtoFlags Flags { get; init; }

        public class ThirdPartyCountryDtoName
        {
            public string Common { get; init; }
            public string Official { get; init; }
        }

        public class ThirdPartyCountryDtoFlags
        {
            public string Svg { get; init; }
        }
    }

    public class ThirdPartyAddressDto
    {
        public ThirdPartyAddressDtoProperties Adress { get; init; }

        public class ThirdPartyAddressDtoProperties
        {
            public string City { get; init; }
            public string CityCode { get; init; }
            public string Name { get; init; }
            public string Label { get; init; }
            public string PostCode { get; init; }
        }
    }

    private async Task CreateUserRoles()
    {
        var list = await userRoleRepository.GetPagedListAsync(
            new CompanyDtoPagedListParameters(1, null)
        );
        if (list.Count > 0)
            return;

        var entities = new[] { new UserRole(UserRoleEnum.Admin), new UserRole(UserRoleEnum.User) };

        await userRoleRepository.CreateBatchAndSaveAsync(entities);
    }

    private async Task CreateUsers()
    {
        var list = await userRepository.GetPagedListAsync(
            new CompanyDtoPagedListParameters(1, null)
        );
        if (list.Count > 0)
            return;

        var entities = new[]
        {
            new User(
                "admin@soloSail.com",
                "Azerty123.",
                "Admin",
                "SoloSail",
                new UserRole(UserRoleEnum.Admin)
            ),
            new User(
                "user@soloSail.com",
                "Azerty123.",
                "User",
                "SoloSail",
                new UserRole(UserRoleEnum.User)
            )
        };

        await userRepository.CreateBatchAndSaveAsync(entities);
    }

    private async Task CreateCities()
    {
        var list = await cityRepository.GetPagedListAsync(
            new CompanyDtoPagedListParameters(1, null)
        );
        if (list.Count > 0)
            return;

        var entities = new[]
        {
            new City("Paris", "75056"),
            new City("Marseille", "13055"),
            new City("Lyon", "69123"),
            new City("Toulouse", "31555"),
            new City("Nice", "06088"),
            new City("Nantes", "44109"),
            new City("Montpellier", "34172"),
            new City("Strasbourg", "67482"),
            new City("Bordeaux", "33063"),
            new City("Lille", "59350")
        };

        await cityRepository.CreateBatchAndSaveAsync(entities);
    }

    private async Task CreateCompanies()
    {
        var list = await companyRepository.GetPagedListAsync(
            new CompanyDtoPagedListParameters(1, null)
        );
        if (list.Count > 0)
            return;

        var paris = await cityRepository.GetByIdAsync<City>(1);
        var strasbourg = await cityRepository.GetByIdAsync<City>(8);
        var france = await countryRepository.GetByIdAsync<Country>(58);

        var entities = new[]
        {
            new Company("ES Energies Strasbourg")
            {
                Country = await countryRepository.GetByIdAsync<Country>(58),
                Address = new Address(strasbourg!, 43, null, "Rue des Marais vert"),
                Contacts = new List<ClientContact>
                {
                    new("John", "Doe")
                    {
                        Address = new Address(paris!, 5, null, "Rue des champions"),
                        Birthdate = new DateOnly(2000, 1, 1),
                        Country = france,
                        ContactInformation = new ContactInformation("0632154876", "john@doe.com")
                    },
                    new("John", "Smith")
                    {
                        Address = new Address(paris!, 32, null, "Rue des pouilleux"),
                        Birthdate = new DateOnly(2000, 1, 1),
                        Country = france,
                        ContactInformation = new ContactInformation("0746134861", "john@smith.com")
                    }
                },
                ClientMissions = new List<ClientMission>
                {
                    new("Une mission")
                    {
                        Project = new ClientMissionProject("Projet pour ES Energies"),
                        CommunicationsHistory = new List<ClientMissionCommunication>(),
                        Contracts = new List<ClientMissionContract>
                        {
                            new("Un contrat"),
                            new("Encore un contrat"),
                            new("Et un autre contrat")
                        },
                        SpecialRequests = new List<ClientMissionSpecialRequest>
                        {
                            new(new DateOnly(2024, 4, 10), "Faire vite"),
                        }
                    }
                },
                FinancialInformation = new ClientFinancialInformation(
                    6472800,
                    PaymentMethodEnum.Card
                )
            },
            new Company("Strasbourg Evenements")
            {
                Country = await countryRepository.GetByIdAsync<Country>(58),
                Address = new Address(strasbourg!, 2, null, "Place de Bordeaux"),
                Contacts = new List<ClientContact>
                {
                    new("Pierre", "Charles")
                    {
                        Address = new Address(paris!, 5, null, "Rue de la gare"),
                        Birthdate = new DateOnly(1960, 1, 1),
                        Country = france,
                        ContactInformation = new ContactInformation(
                            "0333457165",
                            "pierre@charles.com"
                        )
                    }
                },
                ClientMissions = new List<ClientMission>
                {
                    new("Préparation de salle")
                    {
                        Project = new ClientMissionProject("Projet pour Charles"),
                        CommunicationsHistory = new List<ClientMissionCommunication>(),
                        Contracts = new List<ClientMissionContract> { new("Réservations"), },
                        SpecialRequests = new List<ClientMissionSpecialRequest>
                        {
                            new(new DateOnly(2024, 4, 10), "Faire très vite"),
                        }
                    }
                },
                FinancialInformation = new ClientFinancialInformation(
                    1460279,
                    PaymentMethodEnum.Cash
                )
            },
            new Company("ASS Relative Television Europeenne")
            {
                Country = await countryRepository.GetByIdAsync<Country>(58),
                Address = new Address(strasbourg!, 4, null, "Quai du Chanoine Winterer"),
            }
        };

        await companyRepository.CreateBatchAndSaveAsync(entities);
    }
}
