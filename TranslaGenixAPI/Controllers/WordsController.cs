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
        [Route("GetAllWords")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult Get()
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
        [Route("GetRandomWord")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult GetRandomWord()
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
        [Route("GetWordByTag")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult Get(String tag)
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
        [Route("AddWord")]
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
