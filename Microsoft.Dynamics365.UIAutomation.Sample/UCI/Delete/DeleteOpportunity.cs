﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;

namespace Microsoft.Dynamics365.UIAutomation.Sample.UCI
{
    [TestClass]
    public class DeleteOpportunityUCI : TestsBase
    {
        [TestMethod]
        public void UCITestDeleteOpportunity()
        {
            var client = new WebClient(TestSettings.Options);
            using (var xrmApp = new XrmApp(client))
            {
                xrmApp.OnlineLogin.Login(_xrmUri, _username, _password, _mfaSecretKey);

                xrmApp.Navigation.OpenApp(UCIAppName.Sales);

                xrmApp.Navigation.OpenSubArea("Sales", "Opportunities");
                
                xrmApp.Grid.SwitchView("Open Opportunities");

                xrmApp.Grid.OpenRecord(0);

                //Click the Delete button from the command bar
                xrmApp.CommandBar.ClickCommand("Delete", "", false); //Set to true if command is a part of the More Commands menu

                xrmApp.Dialogs.ConfirmationDialog(false); //Click OK on the Delete confirmation dialog (false to cancel)

                xrmApp.ThinkTime(3000);
            }
        }
    }
}
