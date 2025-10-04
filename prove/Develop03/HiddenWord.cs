using System;

public class HiddenWord
{
    private string _content;
    private bool _isVisible;

    public HiddenWord(string content)
    {
        _content = content;
        _isVisible = true;
    }

    public void Conceal()
    {
        _isVisible = false;
    }

    public void Reveal()
    {
        _isVisible = true;
    }

    public bool IsConcealed()
    {
        return !_isVisible;
    }

    public string GetDisplayText()
    {
        if (_isVisible)
        {
            return _content;
        }
        else
        {
            return new string('_', _content.Length);
        }
    }
}