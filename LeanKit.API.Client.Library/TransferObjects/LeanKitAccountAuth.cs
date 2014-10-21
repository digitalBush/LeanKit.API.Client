//------------------------------------------------------------------------------
// <copyright company="LeanKit Inc.">
//     Copyright (c) LeanKit Inc.  All rights reserved.
// </copyright> 
//------------------------------------------------------------------------------

using System.Configuration;

namespace LeanKit.API.Client.Library.TransferObjects
{
    public interface ILeanKitAccountAuth
    {
        string GetAccountUrl();
        string Hostname { get; set; }
    }

    public class LeanKitAccountAuthBase : ILeanKitAccountAuth
    {
        public LeanKitAccountAuthBase()
        {
            UrlTemplateOverride = ConfigurationManager.AppSettings["UrlTemplateOverride"] ?? "https://{0}.leankit.com";
        }

        public string Hostname { get; set; }
        public string UrlTemplateOverride { get; set; }

        public string GetAccountUrl()
        {
            return string.Format(UrlTemplateOverride, Hostname);
        }
    }

    public class LeanKitBasicAuth : LeanKitAccountAuthBase
    {
        public LeanKitBasicAuth()
            : base()
		{
		}

		public string Username { get; set; }

		public string Password { get; set; }
    }

    public class LeanKitTokenAuth : LeanKitAccountAuthBase
    {
        public LeanKitTokenAuth()
            : base()
        {
        }

        public string Token { get; set; }
    }
}