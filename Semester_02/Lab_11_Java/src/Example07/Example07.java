package Example07;

import java.io.File;
import java.io.IOException;
import java.io.RandomAccessFile;
import java.util.Scanner;

public class Example07 {
    //Выполнитьзапись строк и чтение их из файла с произвольным доступом
    public static void main(String[] args) {
        try {
            File folder = new File("ex7_files");
            if (!folder.exists()) {
                folder.mkdir();
            }

            File f1 = new File("ex7_files\\Example7File1.txt");
            if (f1.exists()) {
                f1.delete();
            }
            f1.createNewFile();

            Scanner sc = new Scanner(System.in, "UTF8");
            System.out.print("Сколько строк надо записать в файл? \\n => ");
            int count = sc.nextInt();
            sc.nextLine();  //очистка буфера после ввода числа

            RandomAccessFile rf = new RandomAccessFile(f1, "rw");   // чтение/запись
            rf.setLength(0);    //Устанавливает новую длину файла.
                                // Если файл был больше –он обрезается,
                                // если меньше –расширяется и новое место заполняется нулями
            long len = rf.length();
            System.out.println("Открыт файл размером " + len + " байт");
            System.out.println("Введите строки: ");
            int quantity = 0;   //счетчик букв

            // Записать строки в файл
            for (int i = 0; i < count; i++) {
                String s = sc.nextLine();
                rf.writeUTF(s);
                quantity += s.length();
            }
            len = rf.length();
            System.out.println("Размер файла в байтах = " + len);
            rf.close();

            //Открыть файл для чтения"r"
            rf = new RandomAccessFile(f1, "r");

            // Вывод строк из файла на экран
            System.out.println("Строки из файла: ");
            rf.seek(0);     // перевести указатель в начало файла (на первое слово)
            for (int i = 0; i < count; i++) {
                System.out.println("Строка " + i + " начинается с байта №" + rf.getFilePointer() +
                        " - " + rf.readUTF() + " - заканчивается байтом №" + (rf.getFilePointer() - 1));
            }
            rf.close();

        } catch (IOException e) {
            System.out.println("Err" + e);
        }
    }

}
