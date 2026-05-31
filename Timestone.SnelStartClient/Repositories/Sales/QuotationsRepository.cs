using Timestone.SnelStartClient.Models.Sales;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Sales;

/// <summary>
/// Implementation of the repository for quotations.
/// </summary>
internal sealed class QuotationsRepository : SnelStartRepositoryBase, IQuotationsRepository
{
    /// <summary>
    /// Initializes a new repository for quotations.
    /// </summary>
    public QuotationsRepository(ISnelStartRequestExecutor requestExecutor)
        : base(requestExecutor)
    {
    }

    Task<IReadOnlyList<QuotationModel>> IQuotationsRepository.ListAsync(QuotationQueryOptions? queryOptions, CancellationToken cancellationToken)
        => GetListAsync<QuotationModel>("offertes", queryOptions, cancellationToken);

    Task<QuotationModel?> IQuotationsRepository.GetAsync(Guid id, CancellationToken cancellationToken)
        => GetAsync<QuotationModel>($"offertes/{id}", cancellationToken: cancellationToken);

    Task<QuotationModel?> IQuotationsRepository.CreateAsync(QuotationModel quotation, CancellationToken cancellationToken)
        => PostAsync<QuotationModel>("offertes", quotation, cancellationToken: cancellationToken);

    Task<QuotationModel?> IQuotationsRepository.UpdateAsync(Guid id, QuotationModel quotation, CancellationToken cancellationToken)
        => PutAsync<QuotationModel>($"offertes/{id}", quotation, cancellationToken: cancellationToken);

    Task<bool> IQuotationsRepository.DeleteAsync(Guid id, CancellationToken cancellationToken)
        => DeleteAsync($"offertes/{id}", cancellationToken);
}