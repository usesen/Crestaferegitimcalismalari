namespace VelorusNet8.Domain.Entities.Common;

public interface IEntity
{
    int Id { get; }

    // Override equality methods
    bool Equals(object obj);
    int GetHashCode();
}

