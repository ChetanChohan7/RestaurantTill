using NUnit.Framework;
using RestaurantTill.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace RestaurantTill.StepDefinitions
{
    [Binding]
    public sealed class CheckoutSteps
    {
        [When(@"I am at the checkout")]
        public void WhenIAmAtTheCheckout()
        {
            //
        }

        [When(@"I update to remove (.*) (.*)")]
        public void WhenIUpdateToRemove(int noOfCourses, string courseType)
        {
            string oldTotal = ScenarioContext.Current["TotalCost"].ToString();
            double _oldTotal = Convert.ToDouble(oldTotal);            

            switch (courseType)
            {
                case "starters":
                    double totalStarterCost = noOfCourses * Constants.starterCost;
                    double updatedStarterCost = _oldTotal - totalStarterCost;
                    ScenarioContext.Current.Add("UpdatedCost", updatedStarterCost);
                    break;
                case "mains":
                    double totalMainCost = noOfCourses * Constants.mainCost;
                    double updatedMainCost = _oldTotal - totalMainCost;
                    ScenarioContext.Current.Add("UpdatedCost", updatedMainCost);
                    break;
            }
        }

        [When(@"I update to add (.*) (.*)")]
        public void WhenIUpdateToAdd(int noOfCourses, string courseType)
        {
            string oldTotal = ScenarioContext.Current["TotalCost"].ToString();
            double _oldTotal = Convert.ToDouble(oldTotal);

            switch (courseType)
            {
                case "starters":
                    double totalStarterCost = noOfCourses * Constants.starterCost;
                    double updatedStarterCost = _oldTotal + totalStarterCost;
                    ScenarioContext.Current.Add("UpdatedCost", updatedStarterCost);
                    break;
                case "mains":
                    double totalMainCost = noOfCourses * Constants.mainCost;
                    double updatedMainCost = _oldTotal + totalMainCost;
                    ScenarioContext.Current.Add("UpdatedCost", updatedMainCost);
                    break;
            }
        }

        [Then(@"I can calculate the total cost")]
        public void ThenICanCalculateTheTotalCost(Table table)
        {
            int _numberOfStarters = 0;
            int _numberOfMains = 0;

            string starters = ScenarioContext.Current["Starters"].ToString();
            string mains = ScenarioContext.Current["Mains"].ToString();
            string totalCost = table.Rows[0]["Total"];
            
            Int32.TryParse(starters, out _numberOfStarters);
            Int32.TryParse(mains, out _numberOfMains);

            double expectedTotal = Convert.ToDouble(totalCost);
            double totalStarterCost = _numberOfStarters * Constants.starterCost;
            double totalMainCost = _numberOfMains * Constants.mainCost;
            double actualTotal = totalStarterCost + totalMainCost;

            Assert.AreEqual(expectedTotal, actualTotal);

            ScenarioContext.Current.Add("TotalCost", actualTotal);
        }

        [Then(@"the calculated total cost will be (.*)")]
        public void ThenTheCalculatedTotalCostWillBe(double expectedTotal)
        {
            int _numberOfStarters = 0;
            int _numberOfMains = 0;

            string starters = ScenarioContext.Current["Starters"].ToString();
            string mains = ScenarioContext.Current["Mains"].ToString();

            Int32.TryParse(starters, out _numberOfStarters);
            Int32.TryParse(mains, out _numberOfMains);

            double totalStarterCost = _numberOfStarters * Constants.starterCost;
            double totalMainCost = _numberOfMains * Constants.mainCost;
            double actualTotal = totalStarterCost + totalMainCost;

            Assert.AreEqual(expectedTotal, actualTotal);

        }

        [Then(@"the new total cost will be (.*)")]
        public void ThenTheNewTotalCostWillBe(string newTotal)
        {
            string actualTotal = ScenarioContext.Current["UpdatedCost"].ToString();
            double _actualTotal = Convert.ToDouble(actualTotal);

            double expectedTotal = Convert.ToDouble(newTotal);

            Assert.AreEqual(expectedTotal, _actualTotal);
        }



    }
}
