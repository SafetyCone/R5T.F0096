using System;


namespace R5T.F0096
{
    public class ConfigurationOperator : IConfigurationOperator
    {
        #region Infrastructure

        public static IConfigurationOperator Instance { get; } = new ConfigurationOperator();


        private ConfigurationOperator()
        {
        }

        #endregion
    }
}
