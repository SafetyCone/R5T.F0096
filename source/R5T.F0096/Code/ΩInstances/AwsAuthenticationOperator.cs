using System;


namespace R5T.F0096
{
    public class AwsAuthenticationOperator : IAwsAuthenticationOperator
    {
        #region Infrastructure

        public static IAwsAuthenticationOperator Instance { get; } = new AwsAuthenticationOperator();


        private AwsAuthenticationOperator()
        {
        }

        #endregion
    }
}
