package Task2;

import java.io.*;

public class Task02 {
    public static void main(String[] args) throws IOException {
        BufferedReader bufferedReader = null;
        BufferedWriter bufferedWriter = null;

        try {
            //поток для чтения
            bufferedReader = new BufferedReader(
                                new InputStreamReader(
                                    new FileInputStream("task2_files\\Task2File1.txt"), "UTF8"));
            //поток для записи
            bufferedWriter = new BufferedWriter(
                                new OutputStreamWriter(
                                    new FileOutputStream("task2_files\\Task2File2.txt"), "UTF8"));

            int lineCounter = 0;    //счетчик строк
            String currentString;   //текущая строка текста
            char firstLetter = 'а';       //первая буква первого слова
            char[] punctuationMarks = {',', '.', ':', ';', '"', '»', '«', '!', '?', '-'};  //знаки препинания (для удаления из слов)
            //номер строки из которой берется первое слово
            int firstStringNumber = 1;

            while((currentString = bufferedReader.readLine()) != null) {
                //записать номер строки
                lineCounter++;
                String currentWritingString = lineCounter + ": ";
                //bufferedWriter.write(lineCounter + ": "); TODO

                //проверить, что строка не пустая
                if (currentString.length() != 0) {
                    //выделить отдельные слова из текущей строки и обрезать знаки препинания
                    String[] words = currentString.split(" ");
                    for (int i = 0; i < words.length; i++) {
                        words[i] = cutMarks(words[i], punctuationMarks);
                    }
                    //выбор первой буквы первого слова в тексте (все приводим к нижнему регистру)
                    if (lineCounter == firstStringNumber) {
                        firstLetter = words[0].toLowerCase().charAt(0);
                        System.out.println("Поиск слов на букву \"" + firstLetter +"\": ");
                    }
                    //записать слова, начинающиеся на нужную букву и посчитать их
                    int wordsCounter = 0;

                    for (int i = 0; i < words.length; i++) {
                        if (words[i].toLowerCase().charAt(0) == firstLetter) {
                                currentWritingString += words[i] + ", ";
                            wordsCounter++;
                        }
                    }
                    //убрать последнюю запятую
                    if (currentWritingString.charAt(currentWritingString.length()-2) == ',') {  //TODO нужен ли тут if
                        currentWritingString = currentWritingString.substring(0, currentWritingString.length()-2) + " ";
                    }
                    //записать количество слов
                    currentWritingString += "(количество слов: " + wordsCounter +")";

                } else {
                    //если первая строка будет пустой, ищем первое слово в следующей строке и т.д.
                    firstStringNumber++;
                    //в пустой строке нет слов
                    currentWritingString += "(количество слов: 0)";
                }
                //вывести на консоль и записать текущую строку с нужными словами и кол-вом слов
                System.out.println(currentWritingString);
                bufferedWriter.write(currentWritingString);
                //перевести строку
                bufferedWriter.newLine();
            }
            System.out.println("End");

        } catch (IOException e) {
            System.out.println("Err: " + e);
        } finally {
            bufferedReader.close();
            bufferedWriter.close();
        }
    }

    public static String cutMarks(String word, char[] marks) {
        boolean isCutted = false;

        while(isCutted == false) {
            for (int i = 0; i < marks.length; i++) {
                if (word.charAt(0) == marks[i]) {
                    word = word.substring(1, word.length());
                } else if (word.charAt(word.length()-1) == marks[i]) {
                    word = word.substring(0, word.length() - 1);
                } else {
                    isCutted = true;
                }
            }
        }
        return word;
    }
}

// Создать  проект, позволяющий  из  одного  текстового файла,   содержащего   несколько   строк   (тип   String)
// заранее подготовленного  текста  на русском  языке  (обратитесь  к  классике),
// построчно  переписать  в  другой  текстовый  файл  слова,  отвечающие условию.
// Условие:
// Переписать в результирующий файл слова, которые начинаются с той же буквы, что и первое слово.
// Требования:
// –слова из предложения выделять методом split();
// –в новом файле следует указать номер строки, в которой искомые слова находились в исходномфайле;
// –для каждой строки указать количество выбранныхслов.