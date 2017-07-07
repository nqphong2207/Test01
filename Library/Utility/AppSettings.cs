using System;

namespace Library.Utility
{
    /// <summary>
    /// This class is for getting key/value in Library Config file
    /// </summary>
    public class AppSettings
    {
        public static string EnvironmentName { get { return AssemblySettings.GetConfig()["envirName"].ToString(); } }
        
    }
}

