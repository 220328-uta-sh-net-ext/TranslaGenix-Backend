using Models;

namespace DL
{
    public class WordsRepo : IWordsRepo
    {
        private TGContext db;
        public WordsRepo(TGContext db)
        {
            this.db = db;
        }
        public Words AddWord(Words word)
        {
            db.wordList.Add(word);
            db.SaveChanges();
            return word;
        }
        public List<Words> GetAllWords()
        {
            return db.wordList.ToList();
        }
        public List<Words> GetWordsByTag(string tag)
        {
            return db.wordList.Where(u => u.Tag == tag).ToList();
        }
        public Words GetRandomWord()
        {
            if (db.wordList.ToList().Count() > 0)
            {
                var random = new Random();
                int ranNum = random.Next(0, (db.wordList.ToList().Count()));
                return db.wordList.ToList()[ranNum];
            }
            return default;

        }
    }
}
