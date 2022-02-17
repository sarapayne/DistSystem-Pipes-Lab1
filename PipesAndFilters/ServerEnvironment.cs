﻿using System;
using System.Collections.Generic;
using System.Text;
using PipesAndFilters.Filters;
using PipesAndFilters.Messages;
using PipesAndFilters.Pipes;

namespace PipesAndFilters
{
    static class ServerEnvironment
    {
        private static List<User> Users { get; set; }
        public static User CurrentUser { get; private set; }
        private static IPipe IncomingPipe { get; set; }
        private static IPipe OutgoingPipe { get; set; }

        public static void Setup()
        {
            Users = new List<User>();
            Users.Add(new User() { ID = 1, Name = "Test User" });
            OutgoingPipe = new Pipe();//where is the filter which is required by the constructor?
            OutgoingPipe = new Pipe();//where is the filter which is required by the constructor?
            IncomingPipe.RegisterFilter(new AuthenticateFilter());
            IncomingPipe.RegisterFilter(new TranslateFilter());
            OutgoingPipe.RegisterFilter(new TranslateFilter());
            OutgoingPipe.RegisterFilter(new TimestampFilter());
        }

        public static bool SetCurrentUser(int id)
        {
            foreach (User user in Users)
            {
                if (user.ID == id)
                {
                    CurrentUser = user;
                    return true;
                }
            }

            return false;
        }

        public static IMessage SendRequest(IMessage message)
        {
            // 1. Send the message through the incoming pipeline
            message = IncomingPipe.ProcessMessage(message);

            // 2. Send the message to the endpoint
            HelloWorldEndpoint endpoint = new HelloWorldEndpoint();
            message = endpoint.Execute(message);

            // 3. Send the message through the outgoing pipeline
            message = OutgoingPipe.ProcessMessage(message);

            // 4. Send the message back to the client
            return message;

        }

    }
}
