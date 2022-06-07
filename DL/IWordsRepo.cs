using Models;

namespace DL
{
    public interface IWordsRepo
    {
        /// <summary>
        /// Adds a new word to the db
        /// </summary>
        /// <param name="word"></param>
        /// <returns>Returns the word added to the db</returns>
        Words AddWord(Words word);
        /// <summary>
        /// Gets all words in the DB
        /// </summary>
        /// <returns>Returns a list of all words</returns>
        List<Words> GetAllWords();
        /// <summary>
        /// Gets all
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        List<Words> GetWordsByTag(string tag);

        Words GetRandomWord();
    }
}
