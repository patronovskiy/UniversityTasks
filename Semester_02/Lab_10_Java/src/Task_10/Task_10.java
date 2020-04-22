package Task_10;

import java.io.*;

public class Task_10 {
    public static void main(String[] args) throws IOException {
        BufferedReader br = null;
        PrintWriter out = null;

        try {
            //Создание потоков
            br = new BufferedReader(new InputStreamReader( new FileInputStream("File1Task06.txt"), "cp1251"));
            out = new PrintWriter("File2Task10.txt", "cp1251");

            // Переписывание информации из одного файла в другой
            int lineCount = 0;
            String s;

            while ((s = br.readLine()) != null) {
                lineCount++;
                out.println(lineCount + ":" + s);
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
