package Task_08;

import java.io.*;
import java.net.URL;

public class Task_08 {
    public static void main(String[] args) throws IOException {
        try {
            //с потоком связан файл
            InputStream inFile = new FileInputStream("File1Task06.txt");

            Reader fileReader = new InputStreamReader(inFile, "cp1251");

            readAllByByte(fileReader);
            System.out.println("\n\n");
            inFile.close();
            fileReader.close();

            //с потоком связана интернет-страница
            InputStream inUrl = new URL("http://google.com").openStream();

            Reader rUrl = new InputStreamReader(inUrl, "cp1251");

            readAllByByte(rUrl);
            System.out.println("\n\n");
            inUrl.close();
            rUrl.close();

            //С потоком связан массив типа byte
            InputStream inArray = new ByteArrayInputStream(new byte[] {5, 8, 3, 9, 11});
            Reader rArray = new InputStreamReader(inArray, "cp1251");

            readAllByByte(rArray, true);
            System.out.print("\n\n");
            inArray.close();
            rArray.close();
        } catch (IOException e) {
            System.out.println("Error: " + e);
        }
    }

    public static void readAllByByte (Reader in) throws IOException {
        while (true) {
            int oneByte = in.read();
            if (oneByte != -1) {
                System.out.print((char) oneByte);
            } else {
                System.out.print("\n" + "End");
                break;
            }
        }
    }

    public static void readAllByByte (Reader in, boolean isByte) throws IOException {
        while (true) {
            int oneByte = in.read();
            if (oneByte != -1) {
                if (isByte == true) {
                    System.out.print(oneByte + " ");
                } else {
                    System.out.print((char) oneByte);
                }
            } else {
                System.out.print("\n" + "End");
                break;
            }
        }
    }
}
