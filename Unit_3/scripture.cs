using System;
using System.Collections.Generic;

public class Scripture
{
    private ScriptureReference _reference_RP;
    private List<Word> _words_RP = new List<Word>();
    private Random _rng_RP = new Random();

    public Scripture(ScriptureReference reference_RP, string text_RP)
    {
        _reference_RP = reference_RP;

        string[] splitWords_RP = text_RP.Split(" ");
        foreach (string w_RP in splitWords_RP)
        {
            _words_RP.Add(new Word(w_RP));
        }
    }

    public void HideRandomWords(int count_RP)
    {
        int hiddenCount_RP = 0;

        while (hiddenCount_RP < count_RP)
        {
            int index_RP = _rng_RP.Next(_words_RP.Count);

            if (!_words_RP[index_RP].IsHidden())
            {
                _words_RP[index_RP].Hide();
                hiddenCount_RP++;
            }

            if (IsFullyHidden())
            {
                break;
            }
        }
    }

    public bool IsFullyHidden()
    {
        foreach (Word w_RP in _words_RP)
        {
            if (!w_RP.IsHidden())
            {
                return false;
            }
        }
        return true;
    }

    public string GetDisplayText()
    {
        List<string> displayWords_RP = new List<string>();

        foreach (Word w_RP in _words_RP)
        {
            displayWords_RP.Add(w_RP.GetDisplayText());
        }

        return $"{_reference_RP}\n{string.Join(" ", displayWords_RP)}";
    }
}
