package Task_12;

import java.io.*;
import java.util.ArrayList;

public class Task_12 {
    public static void main(String[] args) throws IOException {
        BufferedReader bufferedReader = null;
        BufferedWriter bufferedWriter = null;

        char[] consonantLetters = { 'б','в','г','д','ж','з','й','к','л','м','н','п','р','с','т','ф','х','ц','ч','ш','щ',
                                    'Б','В','Г','Д','Ж','З','Й','К','Л','М','Н','П','Р','С','Т','Ф','Х','Ц','Ч','Ш','Щ'};
        char[] punctuationMarks = {'.', ',', ':', ';', '?', '!', '(', ')'};

        try {
            // Создание потоков для чтения и записи с нужной кодировкой
            bufferedReader = new BufferedReader(new InputStreamReader(new FileInputStream("Naturemorte.txt")));
            bufferedWriter = new BufferedWriter(new OutputStreamWriter(new FileOutputStream("ConsonantNaturemorte.txt")));

            // Переписывание информации из одного файла в другой
            int lineCount = 0;  //счетчик строк
            String str;
            while((str = bufferedReader.readLine()) != null) {
                lineCount++;
                String consonantStr = lineCount + ": ";
                int wordsCounter = 0;

                //выделение букв, начинающихся на согласные буквы если строка не пустая
                if (str.length() != 0) {
                    String[] initialArray = str.split(" ");

                    for (int i = 0; i < initialArray.length; i++) {
                        String currentWord = clearMarks(initialArray[i], punctuationMarks);
                        if(isConsonant(currentWord, consonantLetters)) {
                            consonantStr += currentWord + " ";
                            wordsCounter ++;
                        }
                    }
                }

                //выбор падежа слова "слово" в счетчике слов
                if (wordsCounter == 1 || wordsCounter == 21) {
                    consonantStr += "(" + wordsCounter + " слово)\n";
                } else if (wordsCounter == 2 || wordsCounter == 3 || wordsCounter == 4
                            || wordsCounter == 22 || wordsCounter == 23 ||wordsCounter == 24) {
                    consonantStr += "(" + wordsCounter + " слова)\n";
                } else {
                    consonantStr += "(" + wordsCounter + " слов)\n";
                }

                System.out.print(consonantStr);
                bufferedWriter.write(consonantStr); // запись без перевода строки
                //bufferedWriter.newLine();   // принудительный переход на новую строку
            }
        } catch (IOException e) {
            System.out.println("Ошибка ввода-вывода: " + e);
        }
    }

    //определить, входит ли первая буква слова в данный алфавит
    // (в нашем случа алфавит согласных букв)
    public static boolean isConsonant(String str, char[] alphabet) {
        for (int i = 0; i < 42; i++) {
            if (str.charAt(0) == alphabet[i]) {
                return true;
            }
        }
        return false;
    }

    //убрать знаки препинания
    public static String clearMarks(String word, char[] marks) {
        for (int i = 0; i < marks.length; i++) {
            if(word.charAt(0) == marks[i]) {
                word = word.substring(1, word.length());
            }
            if(word.charAt(word.length() - 1) == marks[i]) {
                word = word.substring(0, word.length() - 1);
            }
        }
        return word;
    }
}

//    Создать проект, позволяющий из одного текстового файла, содержащего несколько строк (тип String)
//    заранее подготовленного текста на русском языке (Пушкин, Лермонтов или другой российский классик на Ваш  вкус),
//    построчно  переписать  в  другой  текстовый  файл  слова начинающиеся с согласных букв.
//    Требования:
//        – слова из предложения выделять методом split();
//        – в новом файле следует указать номер строки, в которой искомые слова находились в исходном файле;
//        – для каждой строки указать количество выбранных слов.

