using DRApplication.Client.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRApplication.TestProject
{
    public class SubmitButtonTests : TestContext
    {
        [Fact]
        public void ButtonHasUrl()
        {
            //arrange
            var cut = RenderComponent<CancelButton>(parameters => parameters
            .Add(p => p.Url, "myurl"));
            
            //act
            var renderedMarkup = cut.Markup;

            //assert
            Assert.Contains("href=\"myurl\"", renderedMarkup);
        }

        [Fact]
        public void ButtonNavigatesToUrl()
        {
            //arrange
            var cut = RenderComponent<CancelButton>(parameters => parameters
            .Add(p => p.Url, "myurl"));

            //act
            var renderedMarkup = cut.Markup;
            cut.Find("a").Click();

            Assert.
            
        }
    }
}
