using BackendMastery.Architecture.Repository.Consumers;
using BackendMastery.Architecture.Repository.Repositories;

/// <summary>
/// Application entry point.
/// </summary>
/// <remarks>
/// Intuition:
/// - This file owns object creation
/// - It wires abstractions to implementations
///
/// This keeps repository usage clean elsewhere
/// </remarks>
IProductRepository repository = new InMemoryProductRepository();
var viewer = new ProductCatalogViewer(repository);

viewer.DisplayAll();