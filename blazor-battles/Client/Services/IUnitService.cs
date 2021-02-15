using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using blazor_battles.Shared;

namespace blazor_battles.Client.Services
{
    public interface IUnitService
    {
        IList<Unit> Units { get; set; }
        IList<UserUnit> MyUnits { get; set; }
        void AddUnit(int unitId);

        Task LoadUnitsAsync();
    }
}