using Statistic.Application.DTOs;

namespace Statistic.Application.Services;

public interface IVisitorService
{
    /// <summary>
    /// Creates a new visitor and adds it to the visitor repository.
    /// </summary>
    /// <param name="visitorDto">The visitor to be created.</param>
    public Task CreateVisitor(VisitorDto visitorDto);


    /// <summary>
    /// Retrieves all visitors from the visitor repository.
    /// </summary>
    /// <returns>An asynchronous task that returns an enumerable collection of Visitor objects.</returns>
    public Task<IEnumerable<VisitorDto>> GetAll();
}