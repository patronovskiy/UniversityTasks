package Task_09;

import java.io.*;

public class Task_09 {
    public static void main(String[] args) throws IOException {
        BufferedReader br = null;
        BufferedWriter bw = null;

        try {
            // Создание потоков для чтения и записи с нужной кодировкой
            br = new BufferedReader(new InputStreamReader(new FileInputStream("File1Task06.txt")));
            bw = new BufferedWriter(new OutputStreamWriter(new FileOutputStream("File2Task09.txt")));

            // Переписывание информации из одного файла в другой
            int lineCount = 0;  //счетчик строк
            String s;
            while((s = br.readLine()) != null) {
                lineCount++;
                System.out.println(lineCount + ": " + s);
                bw.write(lineCount + ": " + s); // запись без перевода строки
                bw.newLine();   // принудительный переход на новую строку
            }
        } catch (IOException e) {
            System.out.println("Err: " + e);
        } finally {
            br.close();
            bw.flush();
            bw.close();
        }
    }
}
