﻿// /****************************** MessagingSystem ******************************\
// Project:            MessageClient
// Filename:           User.cs
// Created:            16.05.2017
// 
// <summary>
// 
// </summary>
// \***************************************************************************/

using System;
using Realmius.SyncService;
using Realms;

namespace MessageClient.Models
{
    public class User : RealmObject, IRealmiusObjectClient
    {
        [PrimaryKey]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string MobilePrimaryKey => Id;

        public string Name { get; set; }
    }
}