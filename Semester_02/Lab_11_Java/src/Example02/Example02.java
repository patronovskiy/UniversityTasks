package Example02;

import java.io.*;

public class Example02 {
    public static void main(String[] args) throws IOException {
        BufferedReader br = null;
        BufferedWriter out = null;

        try {
            // Создание файловых символьных потоков для чтения и записи
            br = new BufferedReader((new FileReader("ex2_files\\Example2File1.txt")), 1024);    //1024 - размер буфера
            out = new BufferedWriter((new FileWriter("ex2_files\\Example2File2.txt")));

            int lineCount = 0;  //счетчик строк
            String s;

            // Переписывание информации из одного файла в другой
            while((s = br.readLine()) != null) {
                lineCount++;
                System.out.println(lineCount + ": " + s);
                out.write(s);
                out.newLine();  // переход на новуюстроку
            }
        } catch (IOException e) {
            System.out.println("Err: " + e);
        } finally {
            br.close();
            out.flush();
            out.close();
        }
    }
}
