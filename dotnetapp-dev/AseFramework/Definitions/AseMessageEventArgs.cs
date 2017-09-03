namespace DotnetApp.AseFramework.Definitions
{
    using System;

    public class AseMessageEventArgs : EventArgs
    {
        public AseMessageEventArgs(string s)
        {
            this.Message = s;
        }

        public string Message { get; }
    }
}