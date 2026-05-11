/*
 © Copyright 2018 Robert G Marquez - All Rights Reserved
 The source code contained within this file is intended for educational
 purposes only. No warranty as to the quality of the code is expressed or
 implied.
 
 THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS “AS IS” AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE
   
  Feel free to use this code provided you include the copyright notice
  in its entirety.
*/

using Newtonsoft.Json.Linq;
using System;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace ServicesLayer.Tests
{
    [Trait("Category", "Model Validations")]
    public class DepartmentServicesValidationTests : IClassFixture<DepartmentServicesFixture>
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private DepartmentServicesFixture _departmentServicesFixture;
        public DepartmentServicesValidationTests(DepartmentServicesFixture departmentServicesFixture, ITestOutputHelper testOutputHelper)
        {
            this._departmentServicesFixture = departmentServicesFixture;
            _testOutputHelper = testOutputHelper;

            SetValidSampleValues();
        }

        [Fact]
        public void ShouldNotThrowExceptionForDefaultTestValuesOnAnnotations()
        {
            var exception =
                Record.Exception(() => _departmentServicesFixture.DepartmentServices.ValidateModelDataAnnotations(_departmentServicesFixture.DepartmentModel));

            Assert.Null(exception);

            WriteExceptionTestResult(exception);
        }

        [Fact]
        public void ShouldThrowExceptionIfAnyDataAnnotationCheckFails()
        {
            _departmentServicesFixture.DepartmentModel.PhoneNumber = "321-444-333q";
            _departmentServicesFixture.DepartmentModel.Email = "janet4trail.com";


            Exception exception =
                Assert.Throws<ArgumentException>(testCode: () => _departmentServicesFixture.DepartmentServices.ValidateModelDataAnnotations(_departmentServicesFixture.DepartmentModel));

            WriteExceptionTestResult(exception);
        }

        [Fact]
        public void ShouldThrowExceptionForCityLocationEmpty()
        {
            _departmentServicesFixture.DepartmentModel.CityLocation = "";

            Exception exception =
                Assert.Throws<ArgumentException>(testCode: () => _departmentServicesFixture.DepartmentServices.ValidateModelDataAnnotations(_departmentServicesFixture.DepartmentModel));

            WriteExceptionTestResult(exception);
        }

        [Fact]
        public void ShouldThrowExceptionForCityLocationTooShort()
        {
            _departmentServicesFixture.DepartmentModel.CityLocation = "A";

            Exception exception =
                Assert.Throws<ArgumentException>(testCode: () => _departmentServicesFixture.DepartmentServices.ValidateModelDataAnnotations(_departmentServicesFixture.DepartmentModel));

            WriteExceptionTestResult(exception);
        }

        [Fact]
        public void ShouldThrowExceptionForDepartmentUrlWrongHostSuffix()
        {
            _departmentServicesFixture.DepartmentModel.DepartmentUrl = "http://www.mycompany.org";

            Exception exception =
                Assert.Throws<ArgumentException>(testCode: () => _departmentServicesFixture.DepartmentServices.ValidateDepartmentUrl(_departmentServicesFixture.DepartmentModel));

            WriteExceptionTestResult(exception);
        }

        [Fact]
        public void ShouldThrowExceptionForDepartmentUrlWrongProtocol()
        {
            _departmentServicesFixture.DepartmentModel.DepartmentUrl = "https://www.mycompany.com";

            Exception exception =
                Assert.Throws<ArgumentException>(testCode: () => _departmentServicesFixture.DepartmentServices.ValidateDepartmentUrl(_departmentServicesFixture.DepartmentModel));

            WriteExceptionTestResult(exception);
        }

        private void SetValidSampleValues()
        {
            _departmentServicesFixture.DepartmentModel.DepartmentId = 1;
            _departmentServicesFixture.DepartmentModel.CityLocation = "Los Angeles";
            _departmentServicesFixture.DepartmentModel.DepartmentName = "Accounting";
            _departmentServicesFixture.DepartmentModel.Email = "jake.stone@mytest.org";
            _departmentServicesFixture.DepartmentModel.PhoneNumber = "321-444-3333";
            _departmentServicesFixture.DepartmentModel.StateLocation = "California";
            _departmentServicesFixture.DepartmentModel.DepartmentUrl = "http://www.someplace.com/accounting";
        }

        private void WriteExceptionTestResult(Exception exception)
        {
            if (exception != null)
            {
                _testOutputHelper.WriteLine(exception.Message);
            }
            else
            {
                StringBuilder stringBuilder = new StringBuilder();
                JObject json = JObject.FromObject(_departmentServicesFixture.DepartmentModel);
                stringBuilder.Append("***** No Exception Was Thrown ******").AppendLine();
                foreach (JProperty jProperty in json.Properties())
                {
                    stringBuilder.Append(jProperty.Name).Append(" --> ").Append(jProperty.Value).AppendLine();
                }

                _testOutputHelper.WriteLine(stringBuilder.ToString());
            }
        }


    }
}
