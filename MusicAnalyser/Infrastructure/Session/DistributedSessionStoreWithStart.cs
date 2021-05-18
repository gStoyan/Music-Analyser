using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicAnalyser.Infrastructure.Session
{
    public interface IStartSession
    {
        void StartSession(ISession session);
    }

    public class DistributedSessionStoreWithStart : ISessionStore
    {
        DistributedSessionStore innerStore;
        IStartSession startSession;
        public DistributedSessionStoreWithStart(IDistributedCache cache,
            ILoggerFactory loggerFactory, IStartSession startSession)
        {
            innerStore = new DistributedSessionStore(cache, loggerFactory);
            this.startSession = startSession;
        }

        public ISession Create(string sessionKey, TimeSpan idleTimeout,
            TimeSpan ioTimeout, Func<bool> tryEstablishSession,
            bool isNewSessionKey)
        {
            ISession session = innerStore.Create(sessionKey, idleTimeout, ioTimeout,
                 tryEstablishSession, isNewSessionKey);
            if (isNewSessionKey)
            {
                startSession.StartSession(session);
            }
            return session;
        }
    }
}
