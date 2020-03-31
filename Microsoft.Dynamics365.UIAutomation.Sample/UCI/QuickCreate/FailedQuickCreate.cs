// Copyright (c) Microsoft Corporation. All rights reserved. 
// Licensed under the MIT license. 
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using System;
using Microsoft.Dynamics365.UIAutomation.Browser;

namespace Microsoft.Dynamics365.UIAutomation.Sample.UCI
{
    [TestClass]
    public class FailedQuickCreate : TestsBase
    {
        [TestMethod]
        public void QuickCreateFieldConfusion()
        {
            var client = new WebClient(TestSettings.Options);
            using (var xrmApp = new XrmApp(client))
            {
                xrmApp.OnlineLogin.Login(_xrmUri, _username, _password, _mfaSecretKey);

                xrmApp.Navigation.OpenApp(UCIAppName.Sales);

                xrmApp.Navigation.OpenSubArea("Sales", "Contacts");

                xrmApp.CommandBar.ClickCommand("New");

                xrmApp.Entity.SetValue("firstname", TestSettings.GetRandomString(5, 10));

                xrmApp.Navigation.QuickCreate("contact");
                xrmApp.QuickCreate.SetValue("firstname", TestSettings.GetRandomString(5, 10));

                xrmApp.QuickCreate.Cancel();
                
                xrmApp.Dialogs.ConfirmationDialog(false);
            }
        }
    }
}
