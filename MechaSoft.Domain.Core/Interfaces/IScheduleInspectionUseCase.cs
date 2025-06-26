using MechaSoft.Domain.Model;

namespace MechaSoft.Domain.Core.Interfaces;

public interface IScheduleInspectionUseCase
{
    Task<Inspection> ExecuteAsync(ScheduleInspectionRequest request);
}