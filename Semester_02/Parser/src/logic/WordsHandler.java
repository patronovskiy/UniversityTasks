package logic;


public class WordsHandler {
    //class for handling of punctuation
    public static char[] marks = {',', '.', ':', ';', '?', '/', '!', '#', '*', '(', ')', '{', '}', '[', ']', '<', '>', '&', '-'};

    //method for deleting punctuation marks
    public static String handle(String initialWord) {
        String word = initialWord;
        //case when the whole word is a mark (for example, -)
        if (word.length() == 1) {
            for(char mark : marks) {
                if(word.charAt(0) == mark) {
                    return word;
                }
            }
        } else if (word.length() == 0) {
            return word;
        }

        boolean isAllMarksDeleted = false;
        while(!isAllMarksDeleted) {
            isAllMarksDeleted = true;
            for (int i = 0; i < marks.length; i++) {
                if (word.charAt(0) == marks[i]) {
                    word = word.substring(1, word.length());
                    isAllMarksDeleted = false;
                } else if (word.charAt(word.length()-1) == marks[i]) {
                    word = word.substring(0, word.length()-1);
                    isAllMarksDeleted = false;
                }
            }
        }
        return word;
    }
}
