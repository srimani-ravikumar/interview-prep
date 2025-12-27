using BackendMastery.Architecture.SoC.Repository.Output;
using BackendMastery.Architecture.SoC.Repository.Processing;
using BackendMastery.Architecture.SoC.Repository.Repositories;
using BackendMastery.Architecture.SoC.Repository.Validation;

/// <summary>
/// Orchestrates report generation flow.
/// </summary>
/// <remarks>
/// <para>
/// Intuition:
/// - Orchestration is simple
/// - Introducing a Service adds no value
/// </para>
/// <para>
/// This file owns:
/// - Flow
/// - Composition
/// </para>
/// </remarks>
IReportRepository repository = new InMemoryReportRepository();
var validator = new ReportValidator();
var formatter = new ReportFormatter();
var writer = new ReportWriter();

var records = repository.GetAll();

var reportLines = records
    .Where(validator.IsValid)
    .Select(formatter.Format)
    .ToList();

writer.Write(reportLines);