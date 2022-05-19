using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.API
{
    public interface IStateService
    {   
        // Create
        bool AddState(int state_id, int book_id, int amount);
        // Read
        ICollection<IStateData> GetAllStates();
        IStateData GetStateByBookId(int book_id);
        IStateData GetStateByStateId(int state_id);
        // Update
        bool UpdateStateAmount(int state_id, int amount);
        // Delete
        bool DeleteState(int state_id);
    }
}
