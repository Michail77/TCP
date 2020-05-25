using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserSubscription.Models;

namespace UserSubscription.Services
{
    public interface ISubscriptionStorage
    {
        List<Subscription> Subscriptions { get; }

        void Add(Subscription subscription);
    }
}
