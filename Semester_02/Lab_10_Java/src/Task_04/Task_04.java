package Task_04;

import java.io.*;
import java.util.Scanner;

public class Task_04 {
    public static void main(String[] args) throws IOException {
        try {
            //create initial file and write numbers of float type to it
            File f1 = new File("numInitial.txt");
            f1.createNewFile();

            Scanner sc = new Scanner(System.in, "cp1251");

            DataOutputStream wr = new DataOutputStream(new FileOutputStream(f1.getAbsolutePath()));

            System.out.println("How many numbers do you need to write to a file?");
            int count = sc.nextInt();

            System.out.println("Input numbers: ");
            for (int i = 0; i < count; i++) {
                wr.writeFloat(sc.nextFloat());
            }
                wr.flush();
                wr.close();

                //create result file and rewrite numbers to it
                File f2 = new File("ResultTask04.txt");
                f2.createNewFile();

                //stream to read from initial file
                DataInputStream rd = new DataInputStream(new FileInputStream(f1.getAbsolutePath()));

                //stream to write to result file
                wr = new DataOutputStream(new FileOutputStream(f2.getAbsolutePath()));

                try {
                    while(true) {
                        float number = rd.readFloat();
                        wr.writeFloat(number);
                        System.out.println("Number: " + (float) number);
                    }
                } catch (IOException e) {
                    System.out.println("First IOException: " + e);
                }

            wr.flush();
            wr.close();
            rd.close();
            System.out.println("End of file 1");
        } catch (IOException e) {
            System.out.println("End of file");
        }
    }


}
