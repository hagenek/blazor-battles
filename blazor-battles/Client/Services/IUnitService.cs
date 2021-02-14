using System.Collections;
using System.Collections.Generic;
using blazor_battles.Shared;

namespace blazor_battles.Client.Services
{
    public interface IUnitService
    {
        IList<Unit> Units { get; }
        IList<UserUnit> MyUnits { get; set; }
        void AddUnit(int unitId);
    }
}