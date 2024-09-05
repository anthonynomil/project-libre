namespace Models;

public class AddressDtoCreate
{
    public required int CityId { get; init; }

    public required int Number { get; init; }

    public string? NumberComplement { get; init; }

    public required string Road { get; init; }
}
