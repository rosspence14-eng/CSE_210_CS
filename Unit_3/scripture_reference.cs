public class ScriptureReference
{
    private string _book_RP;
    private int _chapter_RP;
    private int _verse_RP;
    private int _endVerse_RP;

    public ScriptureReference(string book_RP, int chapter_RP, int verse_RP)
    {
        _book_RP = book_RP;
        _chapter_RP = chapter_RP;
        _verse_RP = verse_RP;
        _endVerse_RP = -1;
    }

    public ScriptureReference(string book_RP, int chapter_RP, int verse_RP, int endVerse_RP)
    {
        _book_RP = book_RP;
        _chapter_RP = chapter_RP;
        _verse_RP = verse_RP;
        _endVerse_RP = endVerse_RP;
    }

    public override string ToString()
    {
        if (_endVerse_RP == -1)
        {
            return $"{_book_RP} {_chapter_RP}:{_verse_RP}";
        }
        return $"{_book_RP} {_chapter_RP}:{_verse_RP}-{_endVerse_RP}";
    }
}
