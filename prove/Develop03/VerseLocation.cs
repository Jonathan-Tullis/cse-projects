using System;

public class VerseLocation
{
    private string _bookName;
    private int _chapterNumber;
    private int _startVerse;
    private int _endVerse;

    // Constructor for single verse 
    public VerseLocation(string book, int chapter, int verse)
    {
        _bookName = book;
        _chapterNumber = chapter;
        _startVerse = verse;
        _endVerse = verse; // Same as verse for single verse location
    }

    // Constructor for verse range
    public VerseLocation(string book, int chapter, int startVerse, int endVerse)
    {
        _bookName = book;
        _chapterNumber = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    // Returns formatted location text
    public string GetDisplayText()
    {
        if (_startVerse == _endVerse)
        {
            return $"{_bookName} {_chapterNumber}:{_startVerse}";
        }
        else
        {
            return $"{_bookName} {_chapterNumber}:{_startVerse}-{_endVerse}";
        }
    }
}