using DL;
using Models;
using TranslaGenixAPI.Controllers;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace BackendTests
{
    public class WordsTests
    {
        [Fact]
        public void Get_AllWords()
        {
            var mockRepo = new Mock<IWordsRepo>();
            mockRepo.Setup(x => x.GetAllWords()).Returns(new List<Words>());

            var mockCont = new WordsController(mockRepo.Object);

            ActionResult actionResult = mockCont.Ok();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(actionResult);
        }

        [Fact]
        public void Get_RandomWord()
        {
            var mockRepo = new Mock<IWordsRepo>();
            var pointL = new List<Words>();
            var mockPoint = new Words();
            mockRepo.Setup(x => x.GetRandomWord());
            var mockCont = new WordsController(mockRepo.Object);
            ActionResult actionResult = mockCont.Ok();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(actionResult);
        }
        
        [Fact]
        public void Get_WordByTag()
        {
            var mockRepo = new Mock<IWordsRepo>();
            var mockWord = new Words();
            mockWord.Id = 1;
            mockWord.Word = "abc";
            mockWord.Tag = "cba";
            mockRepo.Setup(x => x.GetWordsByTag(It.IsAny<string>()));
            var mockCont = new WordsController(mockRepo.Object);
            ActionResult actionResult = mockCont.Ok("test");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(actionResult);
        }

        [Fact]
        public void Add_NewWord()
        {
            var mockRepo = new Mock<IWordsRepo>();
            var mockword = new Words();
            mockRepo.Setup(x => x.AddWord(new Words())).Returns(mockword);
            var mockCont = new WordsController(mockRepo.Object);
            ActionResult actionResult = mockCont.AddNewWord(mockword);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(actionResult);
        } 
    }
}
