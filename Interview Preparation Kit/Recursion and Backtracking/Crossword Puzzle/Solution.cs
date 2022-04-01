namespace InterviewPreparationKit.RecursionAndBacktracking.CrosswordPuzzle
{
    class Solution
    {
        static string[] CrosswordPuzzle(string[] crossword, string words)
        {
            if (string.IsNullOrEmpty(words))
            {
                return crossword;
            }

            string[] crosswordAttempt = new string[crossword.Length];
            crossword.CopyTo(crosswordAttempt, 0);

            var wordsArray = words.Split(';').ToList();

            for (int row = 0; row < 10; row++)
            {
                int wordSpaceIndex = crosswordAttempt[row].IndexOf('-');

                if (wordSpaceIndex != -1)
                {
                    // if next horizontal space is also a '-', its a horizontal word
                    bool spaceIsHorizontal = wordSpaceIndex < 9 && crosswordAttempt[row][wordSpaceIndex + 1] == '-';
                    int spaceLength = spaceIsHorizontal
                        ? GetSpaceLengthHorizontal(crossword[row], wordSpaceIndex)
                        : GetSpaceLengthVertical(crossword, row, wordSpaceIndex);

                    // Try fill available words
                    for (int i = 0; i < wordsArray.Count; i++)
                    {
                        string startLetter = GetSpaceFilledStartLetter(crosswordAttempt, spaceIsHorizontal, wordSpaceIndex, row);

                        var fullWord = wordsArray[i];
                        var word = wordsArray[i].Substring(startLetter.Length, wordsArray[i].Length - startLetter.Length);

                        // If word isn't the same size as the space or word doesn't start with the letter pre-filled in the space
                        if (word.Length != spaceLength || (startLetter.Length > 0 && startLetter != fullWord[0].ToString()))
                            continue;

                        if (spaceIsHorizontal)
                        {
                            // Fill word horizontally
                            crosswordAttempt[row] = crosswordAttempt[row].Replace(crosswordAttempt[row].Substring(wordSpaceIndex, word.Length), word);
                        }
                        else
                        {
                            // Fill word vertically
                            for (int j = 0; j < spaceLength; j++)
                            {
                                crosswordAttempt[row + j] = 
                                    crosswordAttempt[row + j].Substring(0, wordSpaceIndex) + 
                                    word[j] + 
                                    crosswordAttempt[row + j].Substring(wordSpaceIndex + 1, 10 - wordSpaceIndex - 1);
                            }
                        }

                        var newWordsArray = new List<string>(wordsArray);
                        newWordsArray.RemoveAt(i);

                        var finalCrossword = CrosswordPuzzle(crosswordAttempt, string.Join(";", newWordsArray));

                        // If all positions are filled
                        if (!finalCrossword.ToList().Any(a => a.Contains("-")))
                        {
                            return finalCrossword;
                        }
                        else
                        {
                            // Thats not the correct word for this position, remove from the crossword
                            crossword.CopyTo(crosswordAttempt, 0);
                        }
                    }

                    // No word fits in the space, returning;
                    return crosswordAttempt;
                }
            }

            return crossword;
        }

        static int GetSpaceLengthHorizontal(string row, int columnIndex)
        {
            var startIndex = columnIndex;

            while (columnIndex < 10 && row[columnIndex] != '+' && row[columnIndex] != 'X')
            {
                columnIndex++;
            }

            return columnIndex - startIndex;
        }

        static int GetSpaceLengthVertical(string[] crossword, int rowIndex, int columnIndex)
        {
            var index = rowIndex;

            while (index < 10 && crossword[index][columnIndex] != '+' && crossword[index][columnIndex] != 'X')
            {
                index++;
            }

            return index - rowIndex;
        }

        // Check is space was already partially filled
        static string GetSpaceFilledStartLetter(string[] crossword, bool spaceIsHorizontal, int wordSpaceIndex, int row)
        {
            string startLetter = string.Empty;

            // Check is space was already partially filled
            if (spaceIsHorizontal && wordSpaceIndex > 0 && crossword[row][wordSpaceIndex - 1] != '+' && crossword[row][wordSpaceIndex - 1] != 'X')
            {
                startLetter = crossword[row][wordSpaceIndex - 1].ToString();
            }
            else if (!spaceIsHorizontal && row > 0 && crossword[row - 1][wordSpaceIndex] != '+' && crossword[row - 1][wordSpaceIndex] != 'X')
            {
                startLetter = crossword[row - 1][wordSpaceIndex].ToString();
            }

            return startLetter;
        }

        static void Main(string[] args)
        {
            string[] crossword = new string[10];

            var file = new StreamReader(@"Recursion and Backtracking\Crossword Puzzle\testCase1.txt");

            for (int i = 0; i < 10; i++)
            {
                string crosswordItem = file.ReadLine();
                crossword[i] = crosswordItem;
            }

            file.Close();

            string words = "CALIFORNIA;NIGERIA;CANADA;TELAVIV";

            string[] result = CrosswordPuzzle(crossword, words);

            Console.WriteLine(string.Join("\n", result));

            Console.ReadKey();
        }
    }
}
