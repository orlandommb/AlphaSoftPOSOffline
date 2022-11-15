using System;
using ASCamarerosApp.ViewModels;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace ASCamarerosApp.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public class Settings : BaseViewModel
    {



        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        #region EmpresaSettings
        private const string EmpresaKey = "EMPRESA";
        private readonly string EmpresaValue = "";
        #endregion

        #region SucursalSettings
        private const string SucursalKey = "SUCURSAL";
        private readonly string SucursalValue = "";
        #endregion

        #region ConnectionSettings
        private const string ConnectionListKey = "CONNECTIONLIST";
        private readonly string ConnectionListValue = "";

        private const string ProtocolKey = "PROTOCOL";
        private readonly string ProtocolValue = "https://";

        private const string IPOrAddressKey = "IPORHTTPADDRESS";
        private readonly string IPOrAddressValue = "192.168.1.253";

        private const string PortKey = "PORT";
        private readonly string PortValue = "5001";
        #endregion

        #region UserSettings

        private const string UserKey = "LoggedInUser";
        private readonly string UserValue = "";

        #endregion

        #endregion

        public string LoggedInUser
        {
            get
            {
                return AppSettings.GetValueOrDefault(UserKey, UserValue);
            }
            set
            {
                AppSettings.AddOrUpdateValue(UserKey, value);
                OnPropertyChanged("LoggedInUser");
            }
        }

        public string ConnectionListSettings
        {
            get
            {
                return AppSettings.GetValueOrDefault(ConnectionListKey, ConnectionListValue);
            }
            set
            {
                AppSettings.AddOrUpdateValue(ConnectionListKey, value);
                OnPropertyChanged("ConnectionListSettings");
            }
        }

        public string ProtocolSettings
        {
            get
            {
                return AppSettings.GetValueOrDefault(ProtocolKey, ProtocolValue);
            }
            set
            {
                AppSettings.AddOrUpdateValue(ProtocolKey, value);
                OnPropertyChanged("ProtocolSettings");
            }
        }

        public string IPOrAddresslSettings
        {
            get
            {
                return AppSettings.GetValueOrDefault(IPOrAddressKey, IPOrAddressValue);
            }
            set
            {
                AppSettings.AddOrUpdateValue(IPOrAddressKey, value);
                OnPropertyChanged("IPOrAddresslSettings");
            }
        }

        public string PortSettings
        {
            get
            {
                return AppSettings.GetValueOrDefault(PortKey, PortValue);
            }
            set
            {
                AppSettings.AddOrUpdateValue(PortKey, value);
                OnPropertyChanged("PortSettings");
            }
        }

        public string EmpresaSettings
        {
            get
            {
                return AppSettings.GetValueOrDefault(EmpresaKey, EmpresaValue);
            }
            set
            {
                AppSettings.AddOrUpdateValue(EmpresaKey, value);
                OnPropertyChanged("EmpresaSettings");
            }
        }

        public string SucursalSettings
        {
            get
            {
                return AppSettings.GetValueOrDefault(SucursalKey, SucursalValue);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SucursalKey, value);
                OnPropertyChanged("SucursalSettings");
            }
        }

    }
}
