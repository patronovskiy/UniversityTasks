package Example05;

import java.io.*;

public class Example05 {
   public static void main(String[] args)  throws IOException {
       BufferedReader br = null;
       PrintWriter out = null;
       PrintWriter outConsole = null;

       try {
           br = new BufferedReader(new InputStreamReader(new FileInputStream("ex5_files\\Example5File1.txt"), "UTF8"));
           out = new PrintWriter("ex5_files\\Example5File2.txt", "UTF8");   //поток для записи в файл
           outConsole = new PrintWriter(System.out);    //поток для вывода на консоль

           int lineCount = 0;
            String s;

            while((s = br.readLine()) != null) {
                lineCount++;
                out.println(lineCount + ": " + s);
                outConsole.println(lineCount + ": " + s);
            }

       } catch (IOException e) {
            System.out.println("Err: " + e);
       } finally {
           br.close();
           out.flush();
           out.close();
           outConsole.flush();
           outConsole.close();
       }
   }


}
