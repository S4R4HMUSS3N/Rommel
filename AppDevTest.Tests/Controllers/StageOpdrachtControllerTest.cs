using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using AppDevTest.Controllers;
using Moq;
using Data;
using System.Web.Http.Results;

namespace AppDevTest.Tests.Controllers
{
    [TestFixture]
    public class StageOpdrachtControllerTest
    {
        private TestableSOController controller;

        [SetUp]
        public void SetUp()
        {
            controller = TestableSOController.CreateInstance();
        }

        [Test]
        public void Get_stageopdrachtenByTag()
        {

            //Arrange
            List<StageOpdracht> stageopdrachten = new List<StageOpdracht>();
            StageOpdracht stage1 = new StageOpdracht();
            stage1.id = "1";
            stage1.tag = new Tag()
            {
                id = "1",
                tagnaam = "java"
            };
            stage1.title = "javaProject";
            stageopdrachten.Add(stage1);


            controller.stageOpdrachtMock.Setup(repo => repo.getByTag()).Returns(stageopdrachten);

            //Act
            var result = controller.Get() as OkNegotiatedContentResult<IEnumerable<StageOpdracht>>;


            //Assert
            Assert.That(stageopdrachten, Is.Not.Null);

            Assert.That(result.Content, Is.EquivalentTo(stageopdrachten));  //eerst result, daarna het verwachte resultaat

            controller.stageOpdrachtMock.Verify(repo => repo.getByTag(), Times.Once);

        }
    }

    class TestableSOController : StageOpdrachtenController
    {
        public Mock<IStageOpdrachtenRepository> stageOpdrachtMock { get; set; }

        public TestableSOController(Mock<IStageOpdrachtenRepository> soMock) : base(soMock.Object)
        {
            stageOpdrachtMock = soMock;
        }

        public static TestableSOController CreateInstance()
        {
            var stageOpdrachtRepMock = new Mock<IStageOpdrachtenRepository>();
            return new TestableSOController(stageOpdrachtRepMock);
        }



    }
}
