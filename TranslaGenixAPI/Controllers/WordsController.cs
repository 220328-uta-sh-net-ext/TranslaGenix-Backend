using DL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Models;

namespace TranslaGenixAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController : ControllerBase
    {
        private IWordsRepo repo;
        private static List<Words> words = new List<Words>();
        public WordsController(IWordsRepo repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [Route("Get All Words")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<List<Words>> Get()
        {
            try
            {
                words = repo.GetAllWords();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(words);
        }

        [HttpGet]
        [Route("Get Random Word")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<Words> GetRandomWord()
        {
            var word = new Words();
            try
            {
                word = repo.GetRandomWord();
            }
            catch (Exception ex)
            {
                return BadRequest("Random Word did not work. Exception: " + ex);
            }
            return Ok(word);
        }

        [HttpGet]
        [Route("Get Word by Tag")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<List<Words>> Get(String tag)
        {
            List<Words> tempList = new List<Words>();
            try
            {
                tempList = repo.GetWordsByTag(tag);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(tempList);
        }

        [HttpPost]
        [Route("Add Word")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult AddNewWord([FromQuery][BindRequired] Words newword)
        {
            try
            {
                repo.AddWord(newword);
            }
            catch (Exception ex)
            {
                return BadRequest("Bad Request: " + ex);
            }
            return CreatedAtAction("Added ", newword);
        }
    }
}
