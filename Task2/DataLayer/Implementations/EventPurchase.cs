﻿using System;
using DataLayer.API;

namespace DataLayer.Implementations
{
    internal class EventPurchase : IEvent
    {
        private String id;
        private IState state;
        private ICustomer customer;
        private DateTime eventDate;
        public EventPurchase(String id, IState _state, ICustomer _client, DateTime eventDate)
        {
            this.id = id;
            this.state = _state;
            this.customer = _client;
            this.eventDate = eventDate;
        }

        public EventPurchase(IState _state, ICustomer _client)
        {
            this.state = _state;
            this.customer = _client;
            this.eventDate = DateTime.Now;
        }

        public String Id { get { return id; } }
        public IState State { get { return state; } }
        public ICustomer Customer { get { return customer; } }
        public DateTime EventDate
        {
            get { return eventDate; }
            set { eventDate = value; }
        }
    }
}
