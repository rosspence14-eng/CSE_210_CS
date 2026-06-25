public class Word
{
    private string _text_RP;
    private bool _isHidden_RP;

    public Word(string text_RP)
    {
        _text_RP = text_RP;
        _isHidden_RP = false;
    }

    public void Hide()
    {
        _isHidden_RP = true;
    }

    public bool IsHidden()
    {
        return _isHidden_RP;
    }

    public string GetDisplayText()
    {
        if (_isHidden_RP)
        {
            return "_____";
        }
        return _text_RP;
    }
}
