using System;

namespace dotnetapp.AseFramework.Definitions
{
    public class AseMessageEventArgs : EventArgs
    {
        public AseMessageEventArgs(string s)
        {
            Message = s;
        }

        public string Message { get; }
    }
}