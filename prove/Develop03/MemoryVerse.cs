using System;
using System.Collections.Generic;

public class MemoryVerse
{
    private VerseLocation _location;
    private List<HiddenWord> _wordsList;

    public MemoryVerse(VerseLocation location, string text)
    {
        _location = location;
        _wordsList = new List<HiddenWord>();

        string[] wordArray = text.Split(' ');
        
        for (int i = 0; i < wordArray.Length; i++)
        {
            HiddenWord word = new HiddenWord(wordArray[i]);
            _wordsList.Add(word);
        }
    }

    public void ConcealRandomWords(int numberToHide)
    {
        Random random = new Random();
        int wordsConcealed = 0;

        while (wordsConcealed < numberToHide)
        {
            int randomIndex = random.Next(_wordsList.Count);
            
            if (!_wordsList[randomIndex].IsConcealed())
            {
                _wordsList[randomIndex].Conceal();
                wordsConcealed = wordsConcealed + 1;
            }

            if (AllWordsConcealed())
            {
                break;
            }
        }
    }

    public string GetDisplayText()
    {
        string locationText = _location.GetDisplayText();
        string verseText = "";

        for (int i = 0; i < _wordsList.Count; i++)
        {
            verseText = verseText + _wordsList[i].GetDisplayText();
            
            if (i < _wordsList.Count - 1)
            {
                verseText = verseText + " ";
            }
        }

        return locationText + " " + verseText;
    }

    public bool AllWordsConcealed()
    {
        for (int i = 0; i < _wordsList.Count; i++)
        {
            if (!_wordsList[i].IsConcealed())
            {
                return false;
            }
        }
        
        return true;
    }
}