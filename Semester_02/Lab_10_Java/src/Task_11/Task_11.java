package Task_11;

import java.io.*;
import java.util.Scanner;

public class Task_11 {
    public static void main(String[] args) throws IOException {
        int strings = 2;
        int numbers = 5;
        try {
            File f1 = createFile(strings, numbers);

            System.out.println("Initial file:");
            readFile(f1, strings, numbers);

            File f2 = new File("File2Task11.txt");
            f2.createNewFile();
            int[] resultFileStrigsAndNumbers = handleFile(f1, f2, strings, numbers);

            System.out.println("Result file:");
            readFile(f2, resultFileStrigsAndNumbers[0], resultFileStrigsAndNumbers[1]);

        } catch (IOException e) {
            System.out.println("Err: " + e);
        }


    }

    public static File createFile(int strings, int numbers) throws IOException {
            Scanner sc = new Scanner(System.in);
            //create file
            File f1 = new File("File1Task11.txt");
            f1.createNewFile();
            System.out.println("Full path to file: " + f1.getAbsolutePath());

            System.out.println("Input " + strings + " strings to write to file: ");

            // Создается поток для записи с учетом типа данных – DataOutputStream,
            // и ему в качестве параметра передается поток FileOutputStream
            DataOutputStream dOut = new DataOutputStream(new FileOutputStream(f1));

            for (int i = 0; i < strings; i++) {

                String str = sc.nextLine();

                dOut.writeUTF(str +" \n");
            }

            System.out.println("Input " + numbers + " double numbers to write to file: ");
            for (int i = 0; i < numbers; i++) {
                dOut.writeDouble(sc.nextDouble());
            }
            dOut.flush();   // дописываем несохраненные данные на диск
            dOut.close();
            System.out.println("End of writing file\n");

            return f1;
    }

    public static void readFile(File f1, int strings, int numbers) throws IOException {
        //Read and show data from created file
        DataInputStream dIn = new DataInputStream(new FileInputStream(f1));
        try {
            for (int i = 0; i < strings; i++) {
                System.out.print(dIn.readUTF());
            }
            System.out.println();
            for (int i = 0; i < numbers; i++) {
                System.out.println((double) dIn.readDouble());
            }
        } catch (IOException e) {
            System.out.println("Error while reading: " + e);
        }
        System.out.println("End of file\n");
        dIn.close();
    }

    public static int[] handleFile(File f1, File f2, int strings, int numbers) throws IOException {

        DataInputStream dIn2 = new DataInputStream(new FileInputStream(f1));
        DataOutputStream dOut2 = new DataOutputStream(new FileOutputStream(f2));

        //array for counting quantity of strings [0] and positive numbers [1]
        int[] stringsAndNumbers = {0, 0};

        try {
            for (int i = 0; i < strings; i++) {
                String currentString = dIn2.readUTF();
                if (i == 1) {
                    dOut2.writeUTF(currentString);
                    stringsAndNumbers[0]++;
                }
            }
            for (int i = 0; i < numbers; i++) {
                double currentNumber = dIn2.readDouble();
                if (currentNumber >= 0) {
                    dOut2.writeDouble(currentNumber);
                    stringsAndNumbers[1]++;
                }
            }
        } catch (IOException e) {
            System.out.println("Error while handling file: " + e);
        }
        System.out.println("End of handling file\n");
        dIn2.close();
        dOut2.flush();
        dOut2.close();

        return stringsAndNumbers;
    }
}
