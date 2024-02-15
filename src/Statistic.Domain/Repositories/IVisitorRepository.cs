using Statistic.Domain.Entities;

namespace Statistic.Domain.Repositories;

public interface IVisitorRepository
{
    /// <summary>
    /// Creates a new visitor and adds it to the visitor repository.
    /// </summary>
    /// <param name="visitor">The visitor to be created.</param>
    public void CreateVisitor(Visitor visitor);

    /// <summary>
    /// Retrieves all visitors from the visitor repository.
    /// </summary>
    /// <returns>A collection of Visitor objects.</returns>
    public IEnumerable<Visitor> GetAll();

}