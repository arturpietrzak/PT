﻿using System;
using ServiceLayer.API;
using PresentationLayer.API;

namespace PresentationLayer.API
{
    internal class StateModel : IStateModel
    {
        public StateModel(IStateService service)
        {
            Service = service;
        }

        public IStateModelData Transform(IStateData data)
        {
            if (data == null)
            {
                return null;
            }

            return new StateModelData(
                data.State_Id,
                data.Book_Id,
                data.Amount);
        }

        public IStateModelData GetStateByBookId(int id)
        {
            return Transform(Service.GetStateByBookId(id));
        }

        public IStateService Service { get; }

        public bool UpdateStateAmount(int book_id, int newAmount)
        {
            return Service.UpdateStateAmount(book_id, newAmount);
        }
    }
}
