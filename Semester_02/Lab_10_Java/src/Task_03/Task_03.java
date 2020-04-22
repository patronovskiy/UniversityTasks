package Task_03;

import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.util.Arrays;

public class Task_03 {
    public static void main(String[] args) throws IOException {
        String fileName = "text.txt";
        InputStream inFile = null;

        try {
            inFile = new FileInputStream(fileName);
            readAllByArray(inFile);
        } catch (IOException e) {
            System.out.println("Input-output error: " + e);
        } finally {
            if(inFile != null) {
                try {
                    inFile.close();
                } catch (IOException ignore) {
                    /*NOP*/
                }
            }
        }
    }

    //read 5 characters at time (buffer)
    public static void readAllByArray(InputStream in) throws IOException {
        byte[] buff = new byte[5];
        while (true) {
            int count = in.read(buff);
            if (count != -1) {  //if it is not the end of the file
                System.out.println("Count = " + count +
                        ", buff = " + Arrays.toString(buff)
                        + ", str = " + new String(buff, 0, count, "cp1251")); //UTF8
            } else {
                break;
            }
        }
    }
}
