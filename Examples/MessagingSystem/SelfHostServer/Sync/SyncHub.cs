﻿using System;
using Microsoft.AspNet.SignalR.Hubs;
using Realmius.Contracts;
using Realmius.Server;
using Realmius.Server.QuickStart;
using Server.Entities;

namespace Server.Sync
{
    [HubName(Constants.SignalRHubName)]
    public class SyncHub : SignalRRealmiusHub<User>
    {
        public SyncHub()
            : base(new RealmiusServerProcessor<User>(() => new MessagingContext(new ShareEverythingRealmiusServerConfiguration(typeof(User), typeof(Message))), SyncConfiguration.Instance))
        {
            Console.WriteLine("SyncHub created.");
        }

        protected override User CreateUserInfo(HubCallerContext context)
        {
            try
            {
                var deviceId = context.QueryString["deviceId"];

                Console.WriteLine($"Connect client with id '{deviceId}'");

                return new User {Id = deviceId};
            }
            catch (Exception e)
            {
                Console.WriteLine($"User not found");
                return null;
            }
        }
    }
}