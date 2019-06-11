using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace RestaurantTill.StepDefinitions
{
    [Binding]
    public sealed class OrderReceiptSteps
    {
        [Given(@"I have the following order reciept")]
        public void GivenIHaveTheFollowingOrderReciept(Table table)
        {
            string numberOfStarters = table.Rows[0]["Starters"];
            string numberOfMains = table.Rows[0]["Mains"];

            ScenarioContext.Current.Add("Starters", numberOfStarters);
            ScenarioContext.Current.Add("Mains", numberOfMains);
           
        }

        [Given(@"I have (.*) starter courses and (.*) main courses")]
        public void GivenIHaveStarterCoursesAndMainCourses(string numberOfStarters, string numberOfMains)
        {
            ScenarioContext.Current.Add("Starters", numberOfStarters);
            ScenarioContext.Current.Add("Mains", numberOfMains);
        }


    }
}
