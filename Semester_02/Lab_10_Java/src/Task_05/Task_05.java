package Task_05;

import java.io.*;
import java.util.Scanner;

public class Task_05 {
    public static void main(String[] args) throws IOException {
        Scanner sc = new Scanner(System.in);
        System.out.print("Input file name => ");
        String fileName = sc.nextLine();

        try {
            //create file
            File f1 = new File(fileName);
            f1.createNewFile();
            System.out.println("Full path to file: " + f1.getAbsolutePath());

            System.out.print("Input number of lines for writing to file => ");
            int linesNumber = sc.nextInt();

            // Создается поток для записи с учетом типа данных – DataOutputStream,
            // и ему в качестве параметра передается поток FileOutputStream
            DataOutputStream dOut = new DataOutputStream(new FileOutputStream(f1));
            sc.nextLine();  //clean buffer

            for (int i = 0; i < linesNumber; i++) {
                System.out.println("Input line for writing to file: ");
                String str = sc.nextLine();

                dOut.writeUTF(str +" \n");
            }
            dOut.flush();   // дописываем несохраненные данные на диск
            dOut.close();

            //Read and show data from created file
            DataInputStream dIn = new DataInputStream(new FileInputStream(f1));

            for (int i = 0; i < linesNumber; i++) {
                System.out.println(dIn.readUTF());
            }
            System.out.println("End of file");

        } catch (IOException e) {
            System.out.println("Error: " + e);
        }
    }
}
