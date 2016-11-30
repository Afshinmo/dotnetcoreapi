using dotnetcoreapi.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace dotnetcoreapiTest
{
    public class ValuesControllerTest
    {
        [Fact]
        public void Division_Pass()
        {
            // Arrange
            var valueController = new ValuesController();

            // Act
            var result = valueController.Division(10, 2);

            // Assert
            var response = result as OkObjectResult;
            Assert.Equal(200, response.StatusCode);
            Assert.Equal(5, response.Value);
        }

        [Fact]
        public void Division_Fail_DivisionByZero()
        {
            // Arrange
            var valueController = new ValuesController();

            // Act
            var result = valueController.Division(10, 0);

            // Assert
            var response = result as BadRequestResult;
            Assert.Equal(400, response.StatusCode);
        }
    }
}
