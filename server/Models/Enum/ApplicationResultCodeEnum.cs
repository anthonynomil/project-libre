namespace Models.Enum;

public enum ApplicationResultCodeEnum
{
    Unknown = 0,

    Retrieved = 100,
    Created = 101,
    Updated = 102,
    Deleted = 103,
    Populated = 104,

    InvalidCredentials = 200,
    ValidationError = 201,
    AlreadyExists = 202,
    PopulationError = 203,

    FileSystemError = 300,

    DatabaseError = 400,

    ThirdPartyServiceUnavailable = 500,

    Unauthorized = 600,
    NotFound = 601,
    MissingDependency = 602,
}
