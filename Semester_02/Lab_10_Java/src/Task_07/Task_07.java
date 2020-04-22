package Task_07;

import java.io.*;

public class Task_07 {
    public static void main(String[] args) throws IOException {
        BufferedReader br = null;
        BufferedWriter out = null;

        try {
            br = new BufferedReader(new FileReader("File1Task06.txt"));
            out = new BufferedWriter(new FileWriter("File2Task07.txt"));

            int lineCount = 0;  //счетчик строк

            String s;

            while((s = br.readLine()) != null) {
                lineCount++;
                System.out.println(lineCount + ": " + s);
                out.write(s);
                out.newLine();  //переход на новую строку
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
