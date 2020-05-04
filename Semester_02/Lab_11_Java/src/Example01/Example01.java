package Example01;

import java.io.*;

//Reader и Writer - ветви символьных потоков
//посимвольное чтение и запись
public class Example01 {
    public static void main(String[] args) throws IOException {
        Reader in = null;       // можно сразу записать FileReader in = null;
        Writer out = null;      // можно сразу записать FileWriter out =null;

        try {
            in = new FileReader("ex1_files\\Example1File1.txt");
            out = new FileWriter("ex1_files\\Example1File2.txt", true);    //разрешено добавление

            //Данные считываются и записываются побайтно, как и для InputStream/OutputStream
            int oneByte;        // переменная, в которую считываютсяданные
            while((oneByte = in.read()) != -1) {
                //out.write((char) oneByte);     //запись с уничтожением ранее существующих данных

                out.append((char) oneByte);
                System.out.print((char) oneByte);
            }

        } catch (IOException e) {
            System.out.println("Err: " + e);
        } finally {
            in.close();
            out.close();
        }
    }
}
