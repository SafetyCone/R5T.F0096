using System;
using System.Collections.Generic;

using Microsoft.Extensions.Configuration;

using R5T.T0132;
using R5T.T0144;


namespace R5T.F0096
{
    [FunctionalityMarker]
    public partial interface IAwsAuthenticationOperator : IFunctionalityMarker
    {
        public Dictionary<string, RemoteServerAuthentication> GetAwsRemoteServerAuthenticationsByFriendlyName(
            string awsRemoteServerConfigurationJsonFilePath)
        {
            var configuration = ConfigurationOperator.Instance.BuildConfiguration_Synchronous(configurationBuilder =>
            {
                configurationBuilder
                    .AddJsonFile(awsRemoteServerConfigurationJsonFilePath)
                    ;
            });

            var awsRemoveServerConfigurations = F0029.Instances.ConfigurationOperator.Get<AwsServerConnectionSet>(configuration);

            var awsRemoteServerAuthenticationsByFriendlyName = ConfigurationOperator.Instance.GetRemoteServerAuthenticationsByFriendlyName(awsRemoveServerConfigurations);
            return awsRemoteServerAuthenticationsByFriendlyName;
        }

        public RemoteServerAuthentication GetRemoteServerAuthentication(
            string awsRemoteServerConfigurationJsonFilePath,
            string remoteServerFriendlyName)
        {
            var awsRemoteServerAuthenticationsByFriendlyName = this.GetAwsRemoteServerAuthenticationsByFriendlyName(
                awsRemoteServerConfigurationJsonFilePath);

            var technicalBlogRemoteServerAuthentication = awsRemoteServerAuthenticationsByFriendlyName[remoteServerFriendlyName];
            return technicalBlogRemoteServerAuthentication;
        }
    }
}
