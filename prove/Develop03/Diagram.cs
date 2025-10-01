/*
                        Scripture Memorizer - Class Diagram 
                    +----------------------------------+
                    |            Program               |
                    +----------------------------------+
                    | + Main(args: string[])           |
                    +----------------------------------+
                                    |
                                    | uses
                                    |
                                    v
                    +------------------------------------------+
                    |              MemoryVerse                 |
                    +------------------------------------------+
                    | - _location: VerseLocation               |
                    | - _wordsList: List<HiddenWord>           |
                    +------------------------------------------+
                    | + MemoryVerse(location: VerseLocation,   |
                    |   text: string)                          |
                    | + ConcealRandomWords(count: int): void   |
                    | + GetDisplayText(): string               |
                    | + AllWordsConcealed(): bool              |
                    +------------------------------------------+
                            |                    |
                            | has 1              | has many
                            |                    |
                            v                    v
            +---------------------------+   +---------------------------+
            |      VerseLocation        |   |       HiddenWord          |
            +---------------------------+   +---------------------------+
            | - _bookName: string       |   | - _content: string        |
            | - _chapterNumber: int     |   | - _isVisible: bool        |
            | - _startVerse: int        |   +---------------------------+
            | - _endVerse: int          |   | + HiddenWord(content:     |
            +---------------------------+   |   string)                 |
            | + VerseLocation(book:     |   | + Conceal(): void         |
            |   string, chapter: int,   |   | + Reveal(): void          |
            |   verse: int)             |   | + IsConcealed(): bool     |
            | + VerseLocation(book:     |   | + GetDisplayText():       |
            |   string, chapter: int,   |   |   string                  |
            |   startVerse: int,        |   +---------------------------+
            |   endVerse: int)          |
            | + GetDisplayText():       |
            |   string                  |
            +---------------------------+


Encapsulation Principles:
-------------------------
✓ All member variables are private 
✓ All methods are public
✓ Each class has a single responsibility

Class Responsibilities:
-----------------------
• VerseLocation:  Manages and formats scripture location information
• HiddenWord:     Manages individual word visibility and display
• MemoryVerse:    Coordinates the verse text, location, and word concealment
• Program:        Main entry point - runs the application loop

Key Design Decisions:
---------------------
1. MemoryVerse constructor takes VerseLocation and text - clear separation of concerns

2. VerseLocation supports single verse or verse range - flexible for different 
   scripture formats

3. HiddenWord uses _isVisible boolean to track visibility - simple and efficient

4. All classes encapsulate their data - modifications to internal structure 
   won't break other classes

Program Flow:
-------------
1. Main() creates VerseLocation and MemoryVerse
2. Loop: Display verse → Check if done → Get input → Conceal words
3. Exit when user types "quit" or all words are concealed
*/