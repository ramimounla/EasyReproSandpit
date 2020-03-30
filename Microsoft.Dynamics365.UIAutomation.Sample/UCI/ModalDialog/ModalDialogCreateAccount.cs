// Copyright (c) Microsoft Corporation. All rights reserved. 
// Licensed under the MIT license. 
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using System;
using Microsoft.Dynamics365.UIAutomation.Browser;

namespace Microsoft.Dynamics365.UIAutomation.Sample.UCI
{
    [TestClass]
    public class ModalDialogCreateAccount : TestsBase
    {
        [TestMethod]
        public void UCITestModalDialogCreateAccount()
        {
            var client = new WebClient(TestSettings.Options);
            using (var xrmApp = new XrmApp(client))
            {
                xrmApp.OnlineLogin.Login(_xrmUri, _username, _password);

                xrmApp.Navigation.OpenApp(UCIAppName.Sales);

                xrmApp.Navigation.OpenSubArea("Sales", "Accounts");
                xrmApp.CommandBar.ClickCommand("New");

                xrmApp.Entity.SetValue("name", "Main Form Account Name");

                client.Browser.Driver.ExecuteScript("Xrm.Navigation.navigateTo({pageType:'entityrecord', entityName:'account', formType:2},{target: 2, position: 2, width: {value: 80, unit:'%'}})");
                
                xrmApp.ModalDialog.SetValue("name", "Modal Dialog Account Name");

                xrmApp.ModalDialog.Cancel();
                xrmApp.Dialogs.ConfirmationDialog(false);

                xrmApp.ThinkTime(200);
            }
        }

        //[TestMethod]
        //public void UCITestQuickCreateCase()
        //{
        //    using (var xrmApp = CreateApp())
        //    {
        //        xrmApp.Navigation.OpenApp(UCIAppName.CustomerService);

        //        xrmApp.Navigation.QuickCreate("case");

        //        xrmApp.QuickCreate.SetValue(new LookupItem { Name = "customerid", Value = "Adventure" });

        //        xrmApp.QuickCreate.SetValue("title", TestSettings.GetRandomString(5, 10));

        //        xrmApp.QuickCreate.SetValue(new OptionSet { Name = "casetypecode", Value = "Problem" });

        //        xrmApp.QuickCreate.Save();
                
        //        xrmApp.ThinkTime(5.Seconds());
        //    }
        //}

        //[TestMethod]
        //public void UCITestQuickCreateOpportunity()
        //{
        //    var client = new WebClient(TestSettings.Options);
        //    using (var xrmApp = new XrmApp(client))
        //    {
        //        xrmApp.OnlineLogin.Login(_xrmUri, _username, _password, _mfaSecretKey);

        //        xrmApp.Navigation.OpenApp(UCIAppName.Sales);

        //        xrmApp.Navigation.QuickCreate("opportunity");

        //        xrmApp.QuickCreate.Cancel();

        //        xrmApp.Navigation.QuickCreate("opportunity");

        //        xrmApp.QuickCreate.SetValue(new LookupItem { Name = "parentcontactid", Value = "Test" });

        //        xrmApp.QuickCreate.SetValue("name", TestSettings.GetRandomString(5, 10));

        //        xrmApp.QuickCreate.SetValue(new OptionSet() { Name = "msdyn_ordertype", Value = "Work based" });

        //        xrmApp.QuickCreate.SetValue("estimatedclosedate", DateTime.Now.AddDays(45), "MM/dd/yyyy");

        //        string name = xrmApp.QuickCreate.GetValue("name");

        //        string orderType = xrmApp.QuickCreate.GetValue(new OptionSet() { Name = "msdyn_ordertype" });

        //        string estimatedCloseDate = xrmApp.QuickCreate.GetValue("estimatedclosedate");

        //        string parentContact = xrmApp.QuickCreate.GetValue(new LookupItem() { Name = "parentcontactid" });

        //        xrmApp.QuickCreate.Save();

        //    }
        //}
    }
}