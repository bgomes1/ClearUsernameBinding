using System.ServiceModel;
using System;
using System.ServiceModel.Channels;


/*
 * Want more WCF tips?
 * Visit http://webservices20.blogspot.com/
 */


namespace WebServices20.BindingExtenions
{
    public class ClearUsernameBinding : CustomBinding
    {
        private MessageVersion _messageVersion = MessageVersion.None;
        private long _maxReceivedMessageSize = 65536;
        private bool _allowCookies;
        private bool _bypassProxyOnLocal;
        private HostNameComparisonMode _hostNameComparisonMode;
        private long _maxBufferPoolSize = 524288;
        private bool _useDefaultWebProxy = true;
        private TransferMode _transferMode;
        private Uri _proxyAddress;
        private bool _includeTimestamp;

        public void SetMessageVersion(MessageVersion value) => _messageVersion = value;

        public void SetMaxReceivedMessageSize(long value) => _maxReceivedMessageSize = value;

        public void SetAllowCookies(bool value) => _allowCookies = value;

        public void SetBypassProxyOnLocal(bool value) => _bypassProxyOnLocal = value;

        public void SetHostNameComparisonMode(HostNameComparisonMode value) => _hostNameComparisonMode = value;

        public void SetMaxBufferPoolSize(long value) => _maxBufferPoolSize = value;

        public void SetUseDefaultWebProxy(bool value) => _useDefaultWebProxy = value;

        public void SetTransferMode(TransferMode value) => _transferMode = value;

        public void SetProxyAddress(Uri value) => _proxyAddress = value;

        public void SetIncludeTimestamp(bool value) => _includeTimestamp = value;

        public override BindingElementCollection CreateBindingElements()
        {
            var security = SecurityBindingElement.CreateUserNameOverTransportBindingElement();
            security.IncludeTimestamp = _includeTimestamp;

            var transportElement = new AutoSecuredHttpTransportElement
            {
                MaxReceivedMessageSize = _maxReceivedMessageSize,
                AllowCookies = _allowCookies,
                BypassProxyOnLocal = _bypassProxyOnLocal,
                HostNameComparisonMode = _hostNameComparisonMode,
                MaxBufferPoolSize = _maxBufferPoolSize,
                UseDefaultWebProxy = _useDefaultWebProxy,
                TransferMode = _transferMode,
                ProxyAddress = _proxyAddress
            };

            var bindingElements = new BindingElementCollection
            {
                new TextMessageEncodingBindingElement { MessageVersion = _messageVersion },
                security,
                transportElement
            };
            
            return bindingElements;
        }

        public override string Scheme => "http";
    }
}
