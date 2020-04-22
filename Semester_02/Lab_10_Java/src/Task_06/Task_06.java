package Task_06;

import java.io.*;

public class Task_06 {
    public static void main(String[] args) throws IOException {
        Reader in = null;
        Writer out = null;

        try {
            //заранее создадим файл
            File f1 = new File("File1Task06.txt");
            f1.createNewFile();
            DataOutputStream Out = new DataOutputStream(new FileOutputStream(f1));
            String text = "11 22 text 33 \n 44 tyyui 55 66";
            Out.writeUTF(text);
            Out.flush();
            Out.close();

            //потоки для чтения и записи в новый файл побайтово
            in = new FileReader("File1Task06.txt");
            out = new FileWriter("File2Task06.txt, true");

            //Данные считываются и записываются побайтно, как и для
            // InputStream/OutputStream
            int oneByte;
            while((oneByte = in.read()) != -1) {
                // запись с уничтожением ранее существующих данных
                //out.write((char) oneByte);
                // запись с добавлением данных в конец
                out.append((char) oneByte);
                System.out.print((char) oneByte);
            }

        } catch (IOException e) {
            System.out.println("Error: " + e);
        } finally {
            in.close();
            out.close();
        }
    }
}
