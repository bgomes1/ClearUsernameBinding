using System;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;


/*
 * Want more WCF tips?
 * Visit http://webservices20.blogspot.com/
 */

namespace WebServices20.BindingExtenions
{
    internal class ClearUsernameBindingElement : StandardBindingElement
    {
        private ConfigurationPropertyCollection _properties = null;

        protected override void OnApplyConfiguration(Binding binding)
        {
            var clearUsernameBinding = binding as ClearUsernameBinding;
            clearUsernameBinding.SetMessageVersion(MessageVersion);
            clearUsernameBinding.SetMaxReceivedMessageSize(Convert.ToInt64(MaxReceivedMessageSize));
            clearUsernameBinding.SetAllowCookies(AllowCookies);
            clearUsernameBinding.SetBypassProxyOnLocal(BypassProxyOnLocal);
            clearUsernameBinding.SetHostNameComparisonMode(HostNameComparisonMode);
            clearUsernameBinding.SetMaxBufferPoolSize(Convert.ToInt64(MaxBufferPoolSize));
            clearUsernameBinding.SetUseDefaultWebProxy(UseDefaultWebProxy);
            clearUsernameBinding.SetTransferMode(TransferMode);

            if (!string.IsNullOrEmpty(ProxyAddress))
            {
                clearUsernameBinding.SetProxyAddress(new Uri(ProxyAddress));
            }

            clearUsernameBinding.SetIncludeTimestamp(IncludeTimestamp);
        }

        protected override Type BindingElementType => typeof(ClearUsernameBinding);

        protected override ConfigurationPropertyCollection Properties
        {
            get
            {
                if (_properties == null)
                {
                    var properties = base.Properties;
                    properties.Add(new ConfigurationProperty("messageVersion", typeof(MessageVersion), MessageVersion.Soap11, new MessageVersionConverter(), null, ConfigurationPropertyOptions.None));
                    properties.Add(new ConfigurationProperty("maxReceivedMessageSize", typeof(string), "65536"));
                    properties.Add(new ConfigurationProperty("allowCookies", typeof(bool), false));
                    properties.Add(new ConfigurationProperty("bypassProxyOnLocal", typeof(bool), false));
                    properties.Add(new ConfigurationProperty("maxBufferPoolSize", typeof(string), "524288"));
                    properties.Add(new ConfigurationProperty("useDefaultWebProxy", typeof(bool), true));
                    properties.Add(new ConfigurationProperty("hostNameComparisonMode", typeof(HostNameComparisonMode), HostNameComparisonMode.StrongWildcard));
                    properties.Add(new ConfigurationProperty("transferMode", typeof(TransferMode), TransferMode.Buffered));
                    properties.Add(new ConfigurationProperty("proxyAddress", typeof(string), string.Empty));
                    properties.Add(new ConfigurationProperty("includeTimestamp", typeof(bool), true));
                    _properties = properties;
                }
                return _properties;
            }
        }

        public string MaxReceivedMessageSize
        {
            get => (string)this["maxReceivedMessageSize"];
            set => this["maxReceivedMessageSize"] = value;
        }

        public string MaxBufferPoolSize
        {
            get => (string)this["maxBufferPoolSize"];
            set => this["maxBufferPoolSize"] = value;
        }

        public MessageVersion MessageVersion
        {
            get => (MessageVersion)this["messageVersion"];
            set => this["messageVersion"] = value;
        }

        public bool AllowCookies
        {
            get => (bool)this["allowCookies"];
            set => this["allowCookies"] = value;
        }

        public bool BypassProxyOnLocal
        {
            get => (bool)this["bypassProxyOnLocal"];
            set => this["bypassProxyOnLocal"] = value;
        }

        public bool UseDefaultWebProxy
        {
            get => (bool)this["useDefaultWebProxy"];
            set => this["useDefaultWebProxy"] = value;
        }

        public HostNameComparisonMode HostNameComparisonMode
        {
            get => (HostNameComparisonMode)this["hostNameComparisonMode"];
            set => this["hostNameComparisonMode"] = value;
        }

        public TransferMode TransferMode
        {
            get => (TransferMode)this["transferMode"];
            set => this["transferMode"] = value;
        }

        public string ProxyAddress
        {
            get => (string)this["proxyAddress"];
            set => this["proxyAddress"] = value;
        }

        public bool IncludeTimestamp
        {
            get => (bool)this["includeTimestamp"];
            set => this["includeTimestamp"] = value;
        }
    }
}
