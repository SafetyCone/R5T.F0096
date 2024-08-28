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
            var configuration = Instances.ConfigurationOperator.BuildConfiguration_Synchronous(configurationBuilder =>
            {
                configurationBuilder
                    .AddJsonFile(awsRemoteServerConfigurationJsonFilePath)
                    ;
            });

            var awsRemoveServerConfigurations = Instances.ConfigurationOperator.Get<AwsServerConnectionSet>(configuration);

            var awsRemoteServerAuthenticationsByFriendlyName = Instances.ConfigurationOperator.GetRemoteServerAuthenticationsByFriendlyName(awsRemoveServerConfigurations);
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
