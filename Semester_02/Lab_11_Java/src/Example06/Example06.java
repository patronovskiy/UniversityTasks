package Example06;

import java.io.File;
import java.io.IOException;
import java.io.RandomAccessFile;
import java.util.Scanner;

public class Example06 {
    //в примере используем числа типа long, 1 число занимает 8 байт
    public static void main(String[] args) throws IOException {
        try {
            File folder = new File("Ex6_files");
            if (!folder.exists()) {
                folder.mkdir();     //создание папки, если она не существует
            }
                File f1 = new File("Ex6_files\\Example6File1.txt");
            if (f1.exists()) {
                f1.delete();
            }
                f1.createNewFile();

                Scanner sc = new Scanner(System.in, "UTF8");

                System.out.print("Сколько чисел записать в файл?\n=> ");
                int count = sc.nextInt();

                // Открыть файл одновременно для чтения и записи "rw"
                RandomAccessFile rf = new RandomAccessFile(f1, "rw");
                System.out.println("Исходный размер файла в байтах: " + rf.length() +
                                    ", указатель стоит на " + rf.getFilePointer() + "-м байте");

                System.out.println("Введите числа: ");
                for (int i = 0; i < count; i++) {
                    rf.writeLong(sc.nextLong());  //записать числа в файл.
                                                // на каждое число типа long приходится 8 байт
                }
                System.out.println("Новый размер файла в байтах: " + rf.length() +
                                    ", указатель стоит на " + rf.getFilePointer() + "-м байте");
                System.out.println("Количество байт на 1 число: " + rf.length() / count);
                rf.close();

                // Открыть файл только для чтения "r"
                rf = new RandomAccessFile(f1, "r");

                //Прочитать числа из файла и вывести на экран
                System.out.println("\nЧисла в файле:");
                for (int i = 0; i < count; i++) {
                    rf.seek(i*8);   //перевод указателя на текущее число
                                        //при последовательном считывании seek() можно и не использовать
                    System.out.println("Число N" + i + ": " + rf.readLong());
                }

                System.out.println("Числа в обратном порядке:");
                for (int i = count - 1; i >= 0; i--) {
                    rf.seek(i*8);   //seek() использовать обязательно
                    System.out.println("Число N" + i + ": " + rf.readLong());
                }

                rf.seek(rf.length() - 8);   //перевод указателя на последнее число
                System.out.println("Количество чисел в файле: " + rf.length() / 8 +
                                    ", последнее число: " + rf.readLong() +"\n");

                // Поиск заданного числа в файле и определение его номера (номеров
                System.out.print("Введите число, которое нужно найти в файле => ");
                long x = sc.nextLong();
                int quantity = 0;
                for (int i =0; i < count; i++) {
                    rf.seek(i*8);
                    long number = rf.readLong();
                    if (number ==x) {
                        quantity++;
                        System.out.print("номер " + i + ", ");
                    }
                }

                System.out.println("\nКоличество искомых чисел: " + quantity);
                rf.close();

                // СОРТИРОВКА ЧИСЕЛ В ФАЙЛЕ МЕТОДОМ «ПУЗЫРЬКА»
                rf = new RandomAccessFile(f1, "rw");    //открыть для чтения и записи

                for (int  k = 0; k < count; k++) {          //k - номер просмотра
                    for (int i = 0; i < count - 1; i++) {   //i - номер числа
                        rf.seek(i*8);                   //переход к i-тому числу
                        long number1 = rf.readLong();
                        long number2 = rf.readLong();         //запись i-того и (i+1)-го чисел в переменные

                        if (number1 > number2) {            //условие для сортировки по возрастанию
                            rf.seek(i*8);               //возврат указателя на i-тое число
                            rf.writeLong(number2);           //перезапись чисел в другом порядке
                            rf.writeLong(number1);
                        }
                    }
                }

                System.out.println("\nОтсортированные в файле числа: ");
                for (int i = 0; i < count; i++) {
                    rf.seek(i*8);
                    System.out.print(" " + rf.readLong());
                }
                rf.close();

            } catch (IOException e) {
            System.out.println("Err: " + e);
        }
        }

    }

