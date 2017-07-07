using System;
using System.Collections;
using System.Configuration;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Xml;


namespace Library.Utility
{
    /// <summary>
    /// This class is used for getting key/value in setting file
    /// </summary>
    public class AssemblySettings
    {
        private static IDictionary settings;

        /// <summary>
        ///     Contructor of this class
        /// </summary>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public AssemblySettings()
            : this(Assembly.GetCallingAssembly())
        {
        }

        /// <summary>
        ///     Contructor of AssemblySetting class with param
        /// </summary>
        /// <param name="asm">
        /// </param>
        public AssemblySettings(Assembly asm)
        {
            settings = GetConfig(asm, "appSettings");
        }

        /// <summary>
        ///     This is used for reload setting file
        /// </summary>
        public static void ReLoadSettings()
        {
            if (settings != null)
            {
                settings.Clear();
                settings = null;
            }

            settings = GetConfig(Assembly.GetCallingAssembly(), "appSettings");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string this[string key]
        {
            get
            {
                string settingValue = null;
                try
                {


                    if (settings != null)
                    {
                        settingValue = settings[key] as string;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return (settingValue == null ? "" : settingValue);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IDictionary GetConfig()
        {
            return GetConfig("appSettings");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        public static IDictionary GetConfig(string section)
        {
            return GetConfig(Assembly.GetCallingAssembly(), section);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="asm"></param>
        /// <param name="section"></param>
        /// <returns></returns>
        public static IDictionary GetConfig(Assembly asm, string section)
        {
            // Open and parse configuration file for specified
            // assembly, returning collection to caller for future
            // use outside of this class.
            //
            try
            {
                if (settings != null && settings.Count > 0)
                    return settings;

                string cfgFile = asm.CodeBase + ".config";
                string nodeName = section;

                XmlDocument doc = new XmlDocument();
                doc.Load(new XmlTextReader(cfgFile));

                XmlNodeList nodes = doc.GetElementsByTagName(nodeName);

                foreach (XmlNode node in nodes)
                {
                    if (node.LocalName == nodeName)
                    {
                        DictionarySectionHandler handler = new DictionarySectionHandler();
                        settings = (IDictionary)handler.Create(null, null, node);
                    }
                }
                return settings;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
