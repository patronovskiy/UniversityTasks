package Example03;

import java.io.*;
import java.net.URL;

public class Example03 {
    public static void main(String[] args) {
        try {
            //с потоком связан файл
            InputStream inFile = new FileInputStream("ex3_files\\Example3File1.txt");   //байтовый поток
            Reader rFile = new InputStreamReader(inFile, "UTF8");     //символьный поток
            readAllByByte(rFile);
            inFile.close();
            rFile.close();


            //с потоком связана интернет-страница
            InputStream inUrl = new URL("http://google.com").openStream();  //байтовый поток
            Reader rUrl = new InputStreamReader(inUrl, "UTF8");     //символьный поток
            readAllByByte(rUrl);
            inUrl.close();
            rUrl.close();


            //с потоком связан массив типа byte
            InputStream inArray = new ByteArrayInputStream(new byte[] {5, 8, 3, 9, 11});    //байтовый поток
            Reader rArray = new InputStreamReader(inArray);     //символьный поток
            readAllByByte(rArray, true);
            inArray.close();
            rArray.close();

        } catch (IOException e) {
            System.out.println("Err: " + e);
        }
    }

    public static void readAllByByte(Reader in) throws IOException {
        while (true) {
            int oneByte = in.read();
            if (oneByte != -1) {
                System.out.print((char) oneByte);
            } else {
                System.out.print("\nКонец файла\n\n");
                break;
            }
        }
    }

    public static void readAllByByte(Reader in, boolean isBytes) throws IOException {
        while (true) {
            int oneByte = in.read();
            if (oneByte != -1) {
                System.out.print(oneByte + " ");
            } else {
                System.out.print("\nКонец файла\n\n");
                break;
            }
        }
    }
}
