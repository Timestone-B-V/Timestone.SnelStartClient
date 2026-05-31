using Timestone.SnelStartClient.Models.Vat;
using Timestone.SnelStartClient.Queries;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Repositories.Vat;

/// <summary>
/// Repository for VAT declarations.
/// </summary>
public interface IVatDeclarationsRepository
{
    /// <summary>
    /// Gets all available VAT declarations from an administration. OData functionality is available for this operation.
    /// </summary>
    Task<IReadOnlyList<VatDeclarationModel>> ListAsync(VatDeclarationQueryOptions? queryOptions = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a VAT declaration by its identifier.
    /// </summary>
    Task<VatDeclarationModel?> GetAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates the externally filed status for a VAT declaration.
    /// </summary>
    Task<VatDeclarationModel?> UpdateExternalAsync(Guid id, VatDeclarationExternalUpdateModel payload, CancellationToken cancellationToken = default);
}
