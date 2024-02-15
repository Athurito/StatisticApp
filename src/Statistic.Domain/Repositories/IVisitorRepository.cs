using Statistic.Domain.Entities;

namespace Statistic.Domain.Repositories;

public interface IVisitorRepository
{
    /// <summary>
    /// Creates a new visitor and adds it to the visitor repository.
    /// </summary>
    /// <param name="visitor">The visitor to be created.</param>
    public Task CreateVisitor(Visitor visitor);


    /// <summary>
    /// Retrieves all visitors from the visitor repository.
    /// </summary>
    /// <returns>An asynchronous task that returns an enumerable collection of Visitor objects.</returns>
    public Task<IEnumerable<Visitor>> GetAll();

}