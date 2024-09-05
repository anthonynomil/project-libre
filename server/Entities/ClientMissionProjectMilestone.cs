using Entities.Abstract;
using Entities.Helper;

namespace Entities;

public class ClientMissionProjectMilestone : PrimaryKey
{
    private string _name = null!;
    private DateOnly _start;
    private DateOnly _end;

    private ClientMissionProjectMilestone() { }

    public ClientMissionProjectMilestone(string name, DateOnly start, DateOnly end)
    {
        Name = name;
        Start = start;
        End = end;
    }

    public string Name
    {
        get => _name;
        set
        {
            EntityValidator.RequiredString(value, nameof(Name));
            _name = value;
        }
    }

    public DateOnly Start
    {
        get => _start;
        set
        {
            if (_end != default && value > _end)
                throw new ArgumentException(
                    $"{nameof(Start)} cannot be more recent than {nameof(End)}"
                );

            _start = value;
        }
    }

    public DateOnly End
    {
        get => _end;
        set
        {
            if (_start != default && value > _start)
                throw new ArgumentException(
                    $"{nameof(End)} cannot be more recent than {nameof(Start)}"
                );

            _end = value;
        }
    }
}
