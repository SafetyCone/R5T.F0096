using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;
using R5T.T0144;
using R5T.T0145;


namespace R5T.F0096
{
    [FunctionalityMarker]
    public partial interface IConfigurationOperator : IFunctionalityMarker,
        F0029.IConfigurationOperator
    {
        public Dictionary<string, RemoteServerAuthentication> GetRemoteServerAuthenticationsByFriendlyName(
            RemoteServerConnectionSet remoteServerConnectionSet)
        {
            var join =
                from remoteConnectionPair in remoteServerConnectionSet.RemoteServerConnectionsByFriendlyName
                let serverFriendlyName = remoteConnectionPair.Key
                let remoteServerConnection = remoteConnectionPair.Value

                let userAuthenticationFriendlyName = remoteServerConnection.UserAuthenticationFriendlyName
                join userAuthenticationPair in remoteServerConnectionSet.UserAuthenticationsByFriendlyName
                    on userAuthenticationFriendlyName equals userAuthenticationPair.Key
                let userAuthentication = userAuthenticationPair.Value

                select new
                {
                    ServerFriendlyName = serverFriendlyName,
                    RemoteServerAuthentication = new RemoteServerAuthentication
                    {
                        Username = remoteServerConnection.Username,
                        Password = userAuthentication.Password,
                        HostUrl = remoteServerConnection.HostUrl,
                        PrivateKeyFilePath = userAuthentication.PrivateKeyFilePath,
                    }
                };

            var output = join.ToDictionary(
                x => x.ServerFriendlyName,
                x => x.RemoteServerAuthentication);

            return output;
        }
    }
}
