using Timestone.SnelStartClient.Models.Vat;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Vat;

/// <summary>
/// Implementation of the repository for VAT declarations.
/// </summary>
internal sealed class VatDeclarationsRepository : SnelStartRepositoryBase, IVatDeclarationsRepository
{
    /// <summary>
    /// Initializes a new repository for VAT declarations.
    /// </summary>
    public VatDeclarationsRepository(ISnelStartRequestExecutor requestExecutor)
        : base(requestExecutor)
    {
    }

    Task<IReadOnlyList<VatDeclarationModel>> IVatDeclarationsRepository.ListAsync(VatDeclarationQueryOptions? queryOptions, CancellationToken cancellationToken)
        => GetListAsync<VatDeclarationModel>("btwaangiftes", queryOptions, cancellationToken);

    Task<VatDeclarationModel?> IVatDeclarationsRepository.GetAsync(Guid id, CancellationToken cancellationToken)
        => GetAsync<VatDeclarationModel>($"btwaangiftes/{id}", cancellationToken: cancellationToken);

    Task<VatDeclarationModel?> IVatDeclarationsRepository.UpdateExternalAsync(Guid id, VatDeclarationExternalUpdateModel payload, CancellationToken cancellationToken)
        => PutAsync<VatDeclarationModel>($"btwaangiftes/{id}/externAangeven", payload, cancellationToken: cancellationToken);
}