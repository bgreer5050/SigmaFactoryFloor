using SigmaSight.Models.ViewModels;

namespace SigmaSight.Services.Interfaces
{
    public interface IMachineRuntimeService
    {
        Task<bool> AddMachineRuntimeEvent(AddMachineRuntimeEventViewModel item);
    }
}