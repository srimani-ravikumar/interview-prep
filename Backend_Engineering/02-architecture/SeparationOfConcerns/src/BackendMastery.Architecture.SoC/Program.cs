using BackendMastery.Architecture.SoC.Input;
using BackendMastery.Architecture.SoC.Output;
using BackendMastery.Architecture.SoC.Processing;
using BackendMastery.Architecture.SoC.Validation;

/// <summary>
/// Orchestration layer.
/// </summary>
/// <remarks>
/// Intuition:
/// - This file coordinates flow
/// - It owns the sequence
/// - It owns composition
///
/// This is NOT:
/// - business logic
/// - validation logic
/// - processing logic
/// </remarks>
var reader = new FileReader();
var validator = new RecordValidator();
var transformer = new RecordTransformer();
var writer = new ResultWriter();

var records = reader.Read();

var processed = records
    .Where(validator.IsValid)
    .Select(transformer.Transform)
    .ToList();

writer.Write(processed);

Console.ReadLine();