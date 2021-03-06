﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using VXEN.Models.Transaction;

namespace VXEN.Services
{
    public class Session
    {
        dynamic _application;
        dynamic _credentials;
        typeTerminal _terminal;

        private static readonly Lazy<Session> lazy =  new Lazy<Session>(() => new Session());
        public static Session Instance { get { return lazy.Value; } }

        private Session()
        {
        }

        public void ConfigureApplication(dynamic application)
        {
            _application = application;
        }

        public void ConfigureCredentials(dynamic credentials)
        {
            _credentials = credentials;
        }

        public void ConfigureTerminal(typeTerminal terminal)
        {
            _terminal = terminal;
        }

        public APILifeCycle APILifeCycle { get; set; }

        public T GetApplication<T>()
        {
            dynamic application = Activator.CreateInstance(typeof(T));
            application.ApplicationName = _application.ApplicationName;
            application.ApplicationID = _application.ApplicationID;
            application.ApplicationVersion = _application.ApplicationVersion;

            try
            {
                application.ApplicationData = _application.ApplicationData;
                application.IntegrationType = _application.IntegrationType;
            }
            catch(Exception)
            {
            }
            return application;
        }

        public T GetCredentials<T>()
        {
            dynamic credentials = Activator.CreateInstance(typeof(T));
            credentials.AcceptorID = _credentials.AcceptorID;
            credentials.AccountID = _credentials.AccountID;
            credentials.AccountToken = _credentials.AccountToken;
            credentials.NewAccountToken = _credentials.NewAccountToken;
            return credentials;
        }

        public typeTerminal GetTerminal()
        {
            return _terminal;
        }
    }
    public enum APILifeCycle { Certification, Production };
}