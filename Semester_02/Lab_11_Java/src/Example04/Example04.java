package Example04;

import java.io.*;

public class Example04 {
    public static void main(String[] args) throws IOException {
        BufferedReader br = null;
        BufferedWriter bw = null;

        try {
            // Создание потоков для чтения и записи с нужной кодировкой
            br = new BufferedReader(new InputStreamReader(new FileInputStream("ex4_files\\Example4File1.txt"), "UTF8"));

            bw = new BufferedWriter(new OutputStreamWriter(new FileOutputStream("ex4_files\\Example4File2.txt"), "UTF8"));

            // Переписывание информации из одного файла в другой
            int lineCount = 0;
            String s;
            while ((s = br.readLine()) != null) {
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
